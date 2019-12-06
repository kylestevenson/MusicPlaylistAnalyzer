using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MusicPlayerAnalyzer
{
    class musicStats
    {
        private string name;
        private string artist;
        private string album;
        private string genre;
        private int size;
        private int time;
        private int year;
        private int plays;

        public musicStats(string name, string artist, string album, string genre, int size, int time, int year, int plays)
        {
            this.name = name;
            this.artist = artist;
            this.album = album;
            this.genre = genre;
            this.size = size;
            this.time = time;
            this.year = year;
            this.plays = plays;
        }

        public override string ToString()
        {
            return String.Format("Name: {0}, Artist: {1}, Album: {2}, Genre: {3}, Size: {4}, Time: {5}, Year: {6}, Plays: {7}", Name, Artist, Album, Genre, Size, Time, Year, Plays);
        }

        public string Name
        {
            get { return name; }
        }
        public string Artist
        {
            get { return artist; }
        }
        public string Album
        {
            get { return album; }
        }
        public string Genre
        {
            get { return genre; }
        }
        public int Size
        {
            get { return size; }
        }
        public int Time
        {
            get { return time; }
        }
        public int Year
        {
            get { return year; }
        }
        public int Plays
        {
            get { return plays; }
        }
    }
}
