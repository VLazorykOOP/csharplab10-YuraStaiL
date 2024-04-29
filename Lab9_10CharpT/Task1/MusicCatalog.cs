using System.Collections;

namespace Lab9_10CharpT
{
    public class MusicCatalog
    {
        private Hashtable discs;

        public MusicCatalog()
        {
            discs = new Hashtable();
        }

        public void AddMusicCD(MusicCD cd)
        {
            try
            {
                discs.Add(cd.Title, cd);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Помилка при додаванні диска: {ex.Message}");
            }
        }

        public void RemoveMusicCD(string cdTitle)
        {
            try
            {
                if (discs.ContainsKey(cdTitle))
                {
                    discs.Remove(cdTitle);
                } else
                {
                    throw new MusicCdNotExists($"Диск {cdTitle} не видалено. Такого диску не існує");
                }
            } 
            catch (MusicCdNotExists ex)
            {
                Console.WriteLine($"Помилка видалення диску: {ex.Message}");
            }
        }

        public void DisplayCatalog()
        {
            try
            {
                Console.WriteLine("Каталог музичних дисків:");
                foreach (MusicCD cd in discs.Values)
                {
                    cd.DisplayContents();
                    Console.WriteLine();
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Помилка при виведенні каталогу: {ex.Message}");
            }
        }

        public ArrayList FindSongsByArtist(string artist)
        {
            ArrayList matchingSongs = new ArrayList();
            try
            {
                foreach (MusicCD cd in discs.Values)
                {
                    ArrayList songs = cd.FindSongsByArtist(artist);
                    matchingSongs.AddRange(songs);
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Помилка при пошуку пісень виконавця: {ex.Message}");
            }

            return matchingSongs;
        }
    }
}
