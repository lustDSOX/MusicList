using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Console;

namespace Music_Dictionary
{
    internal class Program
    {
        static void Main(string[] args)
        {
            List<Playlist> playlists = new List<Playlist>();

            while (true)
            {
                WritePlaylist();
                string low = new string('_', 100);
                WriteLine(low); 
                WriteLine("\nДобавить плейлист - add\tУдалить плейлист - del");
                string text = ReadLine();
                
                try
                {
                    if (Convert.ToInt32(text) <= playlists.Count)
                    {
                        int number_playlist = Convert.ToInt32(text)-1;
                        while (true)
                        {
                            Clear();
                            int i = 1;
                            foreach (Sound sound in playlists[number_playlist].Sounds)
                            {
                                WriteLine("{0,1}.{1,20} | {2,20}", i, sound.Author, sound.Name);
                                i++;
                            }
                            i = 1;
                            WriteLine(low);
                            WriteLine("\nДобавить песню - add\tУдалить песню - del\nНазад - enter\n");
                            string playlist_text = ReadLine();
                            if(playlist_text == "add")
                            {
                                Clear();
                                WriteLine("Напишите автора и назваание песни через тире\n");
                                string[] new_sound = ReadLine().Split('-');
                                playlists[number_playlist].Sounds.Add(new Sound { Author = new_sound[0], Name = new_sound[1] });
                                WriteLine("Для продолжения нажмите любую кнопку");
                                ReadKey();
                            }
                            else if(playlist_text == "del")
                            {
                                WriteLine("Напишиет номер песни");
                                int number_sound = Convert.ToInt32(ReadLine());
                                WriteLine($"Песня {playlists[number_playlist].Sounds[number_sound - 1].Author} - {playlists[number_playlist].Sounds[number_sound - 1].Name} удалена");
                                playlists[number_playlist].Sounds.RemoveAt(Convert.ToInt32(ReadLine()) - 1);
                                WriteLine("Для продолжения нажмите любую кнопку");
                                ReadKey();
                            }
                            else if(playlist_text == "")
                            {
                                break;
                            }
                        }
                        
                        

                    }
                }
                catch
                {
                    if (text == "del")
                    {
                        if(playlists.Count > 0)
                        {
                            while (true)
                            {
                                WritePlaylist();
                                WriteLine(low);
                                WriteLine("Назад - enter");
                                string del_playlist = ReadLine();
                                if (del_playlist != "")
                                {
                                    try
                                    {
                                        int id = Convert.ToInt32(del_playlist)-1;
                                        WriteLine($"Плейлист {playlists[id].Name} удален");
                                        playlists.RemoveAt(id);
                                        WriteLine("Для подолжения нажмите любую клавишу");
                                        ReadKey();
                                        break;
                                    }
                                    catch { }
                                }
                                else
                                    break;
                                    
                            }
                        }
                        else
                        {
                            Clear();
                            WriteLine("Список плейлисков пуст\n\nДля продолжения нажмите любую клавишу");
                            ReadKey();
                        }

                    }
                    else if (text == "add")
                    {
                        Clear();
                        WriteLine("Напишите название плейлиста\nНазад - enter");
                        string new_playlist = ReadLine();
                        if(new_playlist != "")
                            playlists.Add(new Playlist { Name = new_playlist});
                        WriteLine($"\nПлейлист {new_playlist} добавлен");
                        WriteLine("Для подолжения нажмите любую клавишу");
                        ReadKey();
                    }
                }
                
            }

            void WritePlaylist()
            {
                Clear();
                WriteLine("Выберите пейлист:");

                for (int i = 0; i < playlists.Count; i++)
                {
                    WriteLine($"\t {i + 1}. {playlists[i].Name}");
                }
            }
        }

       

        class Playlist
        {
            public string Name { get; set; }
            public List<Sound> Sounds { get; set; } = new();
        }

        class Sound
        {
            public string Name { get; set; }
            public string Author{ get; set; }
        }
    }
}
