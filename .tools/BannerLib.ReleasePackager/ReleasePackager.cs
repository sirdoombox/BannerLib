using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.IO.Compression;
using System.Linq;
using System.Text;
using System.Xml;
using static System.Console;

namespace BannerLib.ReleasePackager
{
    internal class ReleasePackager
    {
        public static void Main(string[] args) => new ReleasePackager().Run();
        
        // This tool can also be used in unzipped mode to create the SubModule.xml and directory structure based
        // on the current project structure for debugging locally
        // This is an extremely rough tool but it serves it's purpose.
        // Steps for creating a release:
        //     Rebuild solutions in Release config.
        //     Update version number
        //     Run this project.

        private const string c_MODULE_NAME = "BannerLib";
        private const string c_RELEASE_VER = "v0.0.8"; // v is required, major.minor.revision format.
        private const bool c_IS_SINGLEPLAYER_ONLY = true; // if this is false, the module can also be used in multiplayer, leave it false for now.
        
        private const string c_BIN_DIR = "bin/Release";
        private const string c_SUBMODULE_XML_FILENAME = "SubModule.xml";


        private readonly IReadOnlyList<string> m_dependedModules = new[]
        {
            "Native",
            "SandBoxCore",
            "Sandbox",
        };
        private readonly List<string> m_subModuleProjectDirs = new List<string>();

        private void Run()
        {
            var asmDir = Path.GetDirectoryName(new Uri(typeof(ReleasePackager).Assembly.CodeBase).LocalPath);
            Environment.CurrentDirectory = new Uri(Path.Combine(asmDir, "..", "..", "..","..")).LocalPath;
            var subModules = Directory.GetDirectories(Environment.CurrentDirectory)
                .Where(x => !Path.GetFileName(x).StartsWith("."))
                .Where(x => !x.Contains(nameof(ReleasePackager)));
            WriteLine($"Found {subModules.Count()} Submodules:");
            foreach (var directory in subModules)
            {
                m_subModuleProjectDirs.Add(directory);
                IndentedWriteLine(Path.GetFileName(directory));
            }

            var shouldCreateRelease = RequestUserYesNo($"Create Release At {c_RELEASE_VER}?");
            if (!shouldCreateRelease) return;
            var zipRelease = RequestUserYesNo($"Create Zipped Release?");
            Write("Enter Build Path (Default is C:\\): ");
            var userBuildPath = ReadLine();
            if (string.IsNullOrWhiteSpace(userBuildPath) || !Directory.Exists(userBuildPath)) 
                userBuildPath = "C:\\";
            var buildPath = Path.Combine(userBuildPath, c_MODULE_NAME);
            WriteLine($"Creating {(zipRelease ?  string.Empty : "Un")}Zipped Release At Version {c_RELEASE_VER} In {userBuildPath}");
            if(zipRelease) BuildZip(buildPath);
            else BuildUnzipped(buildPath);
            Write("Release Built. Press Any Key To Show File In Explorer And Exit...");
            ReadKey();
            OpenExplorerAtPath($"{buildPath}{(zipRelease ? ".zip" : string.Empty)}");
        }
        
        // This isn't pretty but it does the job.
        public string GenerateSubModuleXml()
        {
            var settings = new XmlWriterSettings
            {
                Indent = true, IndentChars = ("    "), CloseOutput = true, OmitXmlDeclaration = true
            };
            var sb = new StringBuilder();
            using var writer = XmlWriter.Create(sb, settings);
            writer.WriteStartElement("Module");
                WriteClosedElementWithAttribute(writer, "Name", c_MODULE_NAME);
                WriteClosedElementWithAttribute(writer, "Id", c_MODULE_NAME);
                WriteClosedElementWithAttribute(writer, "Version", c_RELEASE_VER);
                WriteClosedElementWithAttribute(writer, "SingleplayerModule", true.ToString().ToLower());
                WriteClosedElementWithAttribute(writer, "MultiplayerModule", (!c_IS_SINGLEPLAYER_ONLY).ToString().ToLower());
                writer.WriteStartElement("DependedModules");
                foreach(var dependency in m_dependedModules)
                    WriteClosedElementWithAttribute(writer, "DependedModule", dependency, "Id");
                writer.WriteEndElement();
                writer.WriteStartElement("SubModules");
            foreach (var subModDir in m_subModuleProjectDirs)
            {
                var subModFullName = Path.GetFileName(subModDir);
                var subModName = subModFullName.Substring(subModFullName.IndexOf('.')+1);
                writer.WriteStartElement("SubModule");
                    WriteClosedElementWithAttribute(writer, "Name", subModFullName);
                    WriteClosedElementWithAttribute(writer, "DLLName", $"{subModFullName}.dll");
                    WriteClosedElementWithAttribute(writer, "SubModuleClassType", $"{subModFullName}.{subModName}SubModule");
                    writer.WriteStartElement("Tags");
                        WriteTag(writer, "DedicatedServerType", "none");
                        WriteTag(writer, "IsNoRenderModeElement", "false");
                    writer.WriteEndElement();
                writer.WriteEndElement();
            }
            writer.WriteEndElement();
            WriteClosedElement(writer, "Xmls");
            writer.WriteEndDocument();
            writer.Flush();
            // Microsoft insist on XHTML standards for some reason, with no option to change it.
            return sb.ToString().Replace(" />", "/>");
        }
        
        
        private void WriteTag(XmlWriter writer, string key, string value)
        {
            writer.WriteStartElement("Tag");
            writer.WriteAttributeString("key", key);
            writer.WriteAttributeString("value", value);
            writer.WriteEndElement();
        }
        
        private void WriteClosedElementWithAttribute(XmlWriter writer, string elementName, string value, string attributeName = "value")
        {
            writer.WriteStartElement(elementName);
            writer.WriteAttributeString(attributeName, value);
            writer.WriteEndElement();
        }

        private void WriteClosedElement(XmlWriter writer, string elementName)
        {
            writer.WriteStartElement(elementName);
            writer.WriteEndElement();
        }

        private void BuildZip(string buildPath)
        {
            var buildPathZip = $"{buildPath}.zip";
            BuildUnzipped(buildPath);
            if(File.Exists(buildPathZip)) File.Delete(buildPathZip);
            ZipFile.CreateFromDirectory(buildPath, buildPathZip, CompressionLevel.Optimal, true);
            WriteLine($"Created Zip At: {buildPathZip}");
            Directory.Delete(buildPath, true);
        }

        private void BuildUnzipped(string buildPath)
        {
            const string binDir = "bin";
            const string binSubDirName = "Win64_Shipping_Client";
            var binSubDir = Path.Combine(buildPath, binDir, binSubDirName);
            if(Directory.Exists(buildPath))
                Directory.Delete(buildPath, true);
            Directory.CreateDirectory(buildPath);
            Directory.CreateDirectory(Path.Combine(buildPath, binDir));
            Directory.CreateDirectory(binSubDir);
            foreach (var subModDir in m_subModuleProjectDirs)
            {
                foreach(var file in Directory.GetFiles(Path.Combine(subModDir, c_BIN_DIR)))
                {
                    File.Copy(file, Path.Combine(binSubDir, Path.GetFileName(file)));
                }
            }
            using var subModuleXmlFile = File.CreateText(Path.Combine(buildPath, c_SUBMODULE_XML_FILENAME));
            WriteLine("Directory Created & Files Copied.");
            subModuleXmlFile.Write(GenerateSubModuleXml());
            WriteLine("Generated SubModule.xml");
            subModuleXmlFile.Flush();
            subModuleXmlFile.Close();
        }
        
        private static void OpenExplorerAtPath(string path)
        {
            var explorerArgs = $"/e, /select, \"{path}\"";
            var info = new ProcessStartInfo {FileName = "explorer", Arguments = explorerArgs};
            Process.Start(info);
        }

        private void IndentedWriteLine(string message)
        {
            WriteLine($"    {message}");
        }

        private bool RequestUserYesNo(string question)
        {
            while (true)
            {
                Write($"{question} [Y/N]: ");
                var input = ReadLine();
                if (string.Equals(input, "Y", StringComparison.OrdinalIgnoreCase)) return true;
                if (string.Equals(input, "N", StringComparison.OrdinalIgnoreCase)) return false;
            }
        }
    }
}