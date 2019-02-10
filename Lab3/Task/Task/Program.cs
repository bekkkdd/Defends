using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
namespace Task
{
    enum FARMode
    {
        DIR,
        FILE
    }
    class Program
    {
        class Layer
        {
            public int selectedItem;
            public int SelectedItem
            {
                get {
                    return selectedItem;
                }
                set {
                    if (value >= Content.Count)
                    {
                        selectedItem = 0;
                    }
                    else if (value < 0)
                    {
                        selectedItem = Content.Count - 1;
                    }
                    else
                    {
                        selectedItem = value;
                    }
                }
            }
            public List<FileSystemInfo> Content
            {
                get;
                set;
            }
            public void Draw()
            {
                Console.BackgroundColor = ConsoleColor.Black;
                Console.Clear();
                for (int i = 0; i < Content.Count; i++)
                {
                        if (selectedItem == i)
                        {
                            Console.BackgroundColor = ConsoleColor.Blue;
                            if(Content[i].GetType() == typeof(FileInfo))
                            Console.ForegroundColor = ConsoleColor.Red;                            
                            else 
                            Console.ForegroundColor = ConsoleColor.White;
                        }
                        else
                        {
                            Console.BackgroundColor = ConsoleColor.Black;
                            if (Content[i].GetType() == typeof(FileInfo))                            
                            Console.ForegroundColor = ConsoleColor.Red;
                            else
                            Console.ForegroundColor = ConsoleColor.White;
                        }
                    Console.WriteLine((i+1)+") "+Content[i].Name);
                }
            }
            public void Delete()
            {
                if(Content[selectedItem].GetType() == typeof(FileInfo))
                {
                    File.Delete(Content[selectedItem].FullName);
                    Console.Clear();
                    Content.RemoveAt(selectedItem);
                    selectedItem--;
                }
                else
                {
                    if (!Directory.EnumerateFileSystemEntries(Content[selectedItem].FullName).Any())
                    {
                        Directory.Delete(Content[selectedItem].FullName);
                        Content.RemoveAt(selectedItem);
                        selectedItem--;
                    }
                }
            }
            public void Rename()
            {
                if(Content[selectedItem].GetType() == typeof(FileInfo))
                {
                    Console.WriteLine("INSERT NEW NAME FOR FILE");
                    string name = Console.ReadLine();
                    File.Move(Content[selectedItem].FullName, Path.GetDirectoryName(Content[selectedItem].FullName) + "//" +name);
                    Console.Clear();
                    selectedItem--;
                }
                else
                {
                    Console.WriteLine("INSERT NEW NAME FOR FOLDER");
                    string name = Console.ReadLine();
                    Directory.Move(Content[selectedItem].FullName, Path.GetDirectoryName(Content[selectedItem].FullName) + "//" + name);
                    Console.Clear();
                    selectedItem--;
                }
            }
          
        }
        static void Main(string[] args)
        {
            
            Stack<Layer> sl = new Stack<Layer>();
            DirectoryInfo root = new DirectoryInfo(@"C:  \Users\Asus\Desktop\Defends");
            DirectoryInfo dir = root;
            sl.Push(new Layer()
            { Content = root.GetFileSystemInfos().ToList(),
                selectedItem = 0
            });
            FARMode mode = FARMode.DIR;
            while (true)
            {
                if(mode == FARMode.DIR)
                    sl.Peek().Draw();
                ConsoleKeyInfo consoleKeyInfo = Console.ReadKey();
                switch (consoleKeyInfo.Key)
                {
                    case ConsoleKey.DownArrow:
                        sl.Peek().SelectedItem++;
                        break;
                    case ConsoleKey.UpArrow:
                        sl.Peek().SelectedItem--;
                        break;
                    case ConsoleKey.Enter:
                        if (sl.Peek().Content.Count != 0)
                        {
                            FileSystemInfo fsi = sl.Peek().Content[sl.Peek().SelectedItem];
                            if(fsi.GetType() == typeof(DirectoryInfo))
                            {
                                DirectoryInfo dir2 = dir =fsi as DirectoryInfo;
                                sl.Push(new Layer
                                { Content = dir2.GetFileSystemInfos().ToList(),
                                selectedItem = 0
                                });
                            }
                            else
                            {
                                mode = FARMode.FILE;
                                Console.BackgroundColor = ConsoleColor.White;
                                Console.Clear();
                                Console.ForegroundColor = ConsoleColor.Black;
                                FileInfo dir2 = fsi as FileInfo;
                                StreamReader sr = new StreamReader(fsi.FullName);
                                Console.WriteLine(sr.ReadToEnd());
                                sr.Close();
                            }
                        }
                        break;
                    case ConsoleKey.Backspace:
                        if (mode == FARMode.DIR)
                        {
                            sl.Pop();
                            FileSystemInfo fsi = sl.Peek().Content[sl.Peek().SelectedItem];
                            dir = fsi as DirectoryInfo;
                        }
                        else
                        {
                            Console.ForegroundColor = ConsoleColor.White;
                            mode = FARMode.DIR;
                        }
                        break;
                    case ConsoleKey.Delete:
                        if (mode == FARMode.DIR)
                            sl.Peek().Delete();
                        break;
                    case ConsoleKey.R:
                        if (mode == FARMode.DIR)
                        {
                            sl.Peek().Draw();
                            sl.Peek().Rename();
                            sl.Peek().Content = dir.GetFileSystemInfos().ToList();
                        }
                        break;
                    default:
                        break;
                }
            }
        }
    }
}
