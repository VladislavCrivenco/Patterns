using System;
using System.Collections.Generic;

namespace Composite
{
    public interface AbstractFile
    {
        void ls();
        void ls(int level);
    }

    public class File : AbstractFile
    {
        private String name;

        public File(String name)
        {
            this.name = name;
        }

        public void ls(){
            ls(0);
        }

        public void ls(int level)
        {
            for (int i = 0; i < level; i++)
            {
                Console.Write("--");
            }
            Console.WriteLine(name);
        }
    }

    // Directory implements the "lowest common denominator"
    public class Directory : AbstractFile
    {
        private String name;
        private List<AbstractFile> includedFiles = new List<AbstractFile>();

        public Directory(String name)
        {
            this.name = name;
        }

        public void add(AbstractFile obj)
        {
            includedFiles.Add(obj);
        }

        public void ls(){
            ls(0);
        }

        public void ls(int level)
        {
            for (int i = 0; i < level; i++)
            {
                Console.Write("--");
            }
            Console.WriteLine(name);
            foreach (var includedFile in includedFiles)
            {
                includedFile.ls(level + 1);
            }
        }
    }

    public class AbstractFileBuilder
    {
        Directory root;

        public AbstractFileBuilder(string name)
        {
            root = new Directory(name);
        }

        public AbstractFileBuilder Add(AbstractFile file)
        {
            root.add(file);

            return this;
        }

        public AbstractFile Build()
        {
            return root;
        }
    }

    public class CompositeDemo
    {
        public static void Main(String[] args)
        {
            var builder = new AbstractFileBuilder("root");

            builder.Add(new File("Don't wary, be happy.mp3"))
                    .Add(new File("track2.m3u"))
                    .Add(new AbstractFileBuilder("scorpions")
                            .Add(new File("Wind of change.mp3"))
                            .Add(new File("Big city night.mp3"))
                            .Build());



            // Directory music = new Directory("MUSIC");
            // Directory scorpions = new Directory("SCORPIONS");
            // Directory dio = new Directory("DIO");
            // File track1 = new File("Don't wary, be happy.mp3");
            // File track2 = new File("track2.m3u");
            // File track3 = new File("Wind of change.mp3");
            // File track4 = new File("Big city night.mp3");
            // File track5 = new File("Rainbow in the dark.mp3");
            // music.add(track1);
            // music.add(scorpions);
            // music.add(track2);
            // scorpions.add(track3);
            // scorpions.add(track4);
            // scorpions.add(dio);
            // dio.add(track5);
            // music.ls();

            builder.Build().ls();
        }
    }
}
