using System.Collections;

namespace Lab9_10CharpT
{
    public class MusicCD
    {
        public string Title { get; set; }
        private Hashtable songs;

        public MusicCD(string title)
        {
            Title = title;
            songs = new Hashtable();
        }

        public void AddSong(Song song)
        {
            try
            {
                songs.Add(song.Title, song);
            }
            catch (Exception ex) when (ex is OutOfMemoryException || ex is OverflowException)
            {
                Console.WriteLine("Помилка: Проблема з розміром пам'яті або переповнення.");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Помилка при додаванні пісні: {ex.Message}");
            }
        }

        public void RemoveSong(string songTitle)
        {
            try
            {
                if (songs.ContainsKey(songTitle))
                {
                    songs.Remove(songTitle);
                } else
                {
                    throw new SoundNotExists($"Пісня {songTitle} не видалена. Вона не існує на цьому диску");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Помилка при видаленні пісні: {ex.Message}");
            }
        }

        public void DisplayContents()
        {
            Console.WriteLine($"Музичний диск \"{Title}\":");
            foreach (Song song in songs.Values)
            {
                Console.WriteLine($"{song.Title} - {song.Artist}");
            }
        }

        public ArrayList FindSongsByArtist(string artist)
        {
            ArrayList matchingSongs = new ArrayList();
            try
            {
                foreach (Song song in songs.Values)
                {
                    if (song.Artist.Equals(artist, StringComparison.OrdinalIgnoreCase))
                    {
                        matchingSongs.Add(song);
                    }
                }
            }
            catch (Exception ex) when (ex is ArrayTypeMismatchException || ex is IndexOutOfRangeException ||
                                        ex is InvalidCastException || ex is StackOverflowException)
            {
                Console.WriteLine("Помилка: Проблема з обробкою даних або переповнення стеку.");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Помилка при пошуку пісень виконавця: {ex.Message}");
            }

            return matchingSongs;
        }
    }
}
