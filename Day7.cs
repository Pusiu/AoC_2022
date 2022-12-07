using System.Dynamic;
using System.Security.Cryptography.X509Certificates;
namespace AoC_2022
{
    class Day7 : Day
    {
        public override string Part1()
        {
            return  CreateFilesystem().GetDirectoriesBySize(100000).Sum(x => x.size).ToString();
        }

        Directory CreateFilesystem()
        {
            Directory root = null;
            Directory currentDirectory = null;
            foreach (var line in input.Replace("\r", "").Split("\n", StringSplitOptions.RemoveEmptyEntries))
            {
                if (line[0] == '$')
                {
                    (string command, string parameter) = line.Split(" ") switch { var a => a.Length >= 3 ? (a[1], a[2]) : (a[1], "") };
                    switch (command)
                    {
                        case "cd":
                            if (parameter != "..")
                            {
                                if (root == null)
                                {
                                    currentDirectory = new Directory(parameter, null);
                                    root = currentDirectory;
                                }
                                else
                                {
                                    var dir = currentDirectory.files.FirstOrDefault(x => x.filename == parameter);
                                    if (dir == null)
                                        dir = new Directory(parameter, currentDirectory);

                                    currentDirectory = dir as Directory;
                                }
                            }
                            else
                            {
                                currentDirectory = currentDirectory.parent;
                            }
                            break;
                        case "ls":

                            break;
                    }
                }
                else
                {
                    (string nfo, string name) = line.Split(" ") switch { var a => (a[0], a[1]) };
                    if (nfo == "dir")
                    {
                        currentDirectory.AddFile(new Directory(name, currentDirectory));
                    }
                    else
                    {
                        currentDirectory.AddFile(new File(name, long.Parse(nfo), currentDirectory));
                    }
                }
            }

            return root;
        }

        public override string Part2()
        {
            long totalDiskSpace=70000000;
            long desiredFreeSpace=30000000;
            List<Directory> allDirs = CreateFilesystem().GetDirectoriesBySize(totalDiskSpace);
            long currentlyUsedSpace=allDirs.First().size;

            return allDirs.Where(x => totalDiskSpace-(currentlyUsedSpace-x.size) >= desiredFreeSpace).OrderBy(x => x.size).First().size.ToString();
        }

        class File
        {
            public string filename;
            public long size;

            public Directory parent = null;

            public File(string filename, long size, Directory parent)
            {
                this.filename = filename;
                this.size = size;
                this.parent = parent;
            }
        }

        class Directory : File
        {
            public List<File> files = new List<File>();

            public Directory(string name, Directory parent) : base(name, 0, parent)
            {
            }

            public void AddFile(File f)
            {
                files.Add(f);
                size += f.size;
                var curParrent = parent;
                while (curParrent != null)
                {
                    curParrent.size += f.size;
                    curParrent = curParrent.parent;
                }
            }

            public List<Directory> GetDirectoriesBySize(long maxSize)
            {
                List<Directory> l = new List<Directory>();
                if (size <= maxSize)
                    l.Add(this);
                foreach (var f in files)
                {
                    if (f is Directory d)
                    {
                        l.AddRange(d.GetDirectoriesBySize(maxSize));
                    }
                }
                return l;
            }

            public void PrintDirectory(int indentation = 0)
            {
                Console.Write($"- {string.Join("", Enumerable.Range(0, indentation).Select(x => "\t"))} {filename} (dir)\n");
                indentation++;
                foreach (var f in files)
                {
                    if (f is Directory dir)
                        dir.PrintDirectory(indentation);
                    else
                        Console.WriteLine($"- {string.Join("", Enumerable.Range(0, indentation).Select(x => "\t"))} {f.filename} ({$"file, size={f.size}"})");
                }
            }
        }
    }
}