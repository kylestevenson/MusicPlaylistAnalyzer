using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MusicPlayerAnalyzer
{
    class Program
    {
        static void Main(string[] args)
        {
            var songs = new List<musicStats>();

            //check if enough arguments are supplied in command line
            if (args.Length < 2)
            {
                Console.WriteLine("Music Player Analyzer <music_playlist_file_path> <report_file_path>");
                Console.WriteLine("Supply a csv data file and a file to output the report.");
                System.Environment.Exit(1);
            }
            var inputFile = args[0];
            var outputFile = args[1];
            
            // read from input, place into songs
            StreamReader sr = null;
            try
            {
                sr = new StreamReader(inputFile);
                string line = null;
                string[] values;

                sr.ReadLine();//read first line and do nothing
                while ((line = sr.ReadLine()) != null)
                {
                    values = line.Split('\t');
                    songs.Add(new musicStats(values[0], values[1], values[2], values[3], Int32.Parse(values[4]), Int32.Parse(values[5]), Int32.Parse(values[6]), Int32.Parse(values[7])));
                }
                sr.Close();
            } catch (Exception ex)
            {
                Console.WriteLine("Error while reading {0}: {1}", inputFile, ex.Message);
                System.Environment.Exit(2);
            } finally
            {
                if (sr != null)
                {
                    sr.Close();
                }
            }

            //LINQ for report data

            //song with more than 200 plays
            var songsWith200plays = from song in songs where song.Plays >= 200 select song;
            //songs with genre 'Alternative'
            var altSongs = from song in songs where song.Genre == "Alternative" select song;
            //songs with genre 'hip-hop/rap'
            var rapSongs = from song in songs where song.Genre == "Hip-Hop/Rap" select song;
            //songs from albumn 'Welcome to the fishbowl?'
            var fishBowlAlbum = from song in songs where song.Album == "Welcome to the Fishbowl" select song;
            //songs with year before 1970
            var before1970 = from song in songs where song.Year < 1970 select song;
            //songs with names longer than 85 characters
            var longSongNames = from song in songs where song.Name.Length > 85 select song;
            //longest song time
            var longestSongTime = (from song in songs orderby song.Time descending select song).First();

            //Write report to output file
            // check output file can be written to
            StreamWriter sw = null;
            try
            {
                sw = new StreamWriter(outputFile);
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error openening to write to {0}: {1}", outputFile, ex.Message);
            }
            //create report
            string report = "Music Playlist Report\n";
            report += "\nSongs that received 200 or more plays:\n";
            foreach (musicStats song in songsWith200plays)
            {
                report += song + "\n";
            }

            int count = 0;
            foreach (musicStats song in altSongs)
            {
                count++;
            }
            report += "\nNumber of Alternative songs: " + count + "\n";

            count = 0;
            foreach (musicStats song in rapSongs)
            {
                count++;
            }
            report += "\nNumber of Hip-Hop/Rap songs: " + count + "\n";

            report += "\nSongs from the album Welcome to the Fishbowl:\n";
            foreach (musicStats song in fishBowlAlbum)
            {
                report += song + "\n";
            }

            report += "\nSongs from before 1970:\n";
            foreach (musicStats song in before1970)
            {
                report += song + "\n";
            }

            report += "\nSongs names longer than 85 characters:\n";
            foreach (musicStats song in longSongNames)
            {
                report += song + "\n";
            }

            report += "\nLongest song: " + longestSongTime;

            //write report to output file
            sw.Write(report);
            sw.Close();

            Console.WriteLine("Music data successfully analyzed from {0}, report saved to {1}.", inputFile, outputFile);

            Console.ReadLine();
        }
    }
}
