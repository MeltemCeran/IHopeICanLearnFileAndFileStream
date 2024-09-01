using System.Text;

namespace FileFileStreamDers
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.InputEncoding = System.Text.Encoding.Unicode;
            Console.OutputEncoding = System.Text.Encoding.Unicode;
            Console.CursorVisible = false;
            Console.ResetColor();

            // System.IO (Input/Output)
            /*
             * File -> FileInfo
             * FileStream -> StreamReader -> StreamWriter
             * Directory -> DirectoryInfo
             * DriveInfo
             * Path
             * 
             */

            //DosyaIslemleriOrnek1();
            //DosyaIslemleriOrnek2();
            //DosyaIslemleriOrnek3();
            DosyaIslemleriOrnek4();
          //  DosyaIslemleriOrnek5();
            //KlasorIslemleriOrnek1();
           // KlasorIslemleriOrnek2();

        }

        private static void KlasorIslemleriOrnek2()
        {
            while (true)
            {
                Menu("Ana Menü | Dos Uygulaması V 1.0", "(D)osyalar", "(K)lasörler", "(C)ıkış");

                ConsoleKeyInfo keyInfo = Console.ReadKey(true);

                while (keyInfo.Key != ConsoleKey.C && keyInfo.Key != ConsoleKey.D && keyInfo.Key != ConsoleKey.K)
                {
                    keyInfo = Console.ReadKey(true);
                }

                switch (keyInfo.Key)
                {
                    case ConsoleKey.D:
                        FileOperations();
                        break;
                    case ConsoleKey.K:
                        Console.Write("Klasör Adı : ");
                        string folderName = Console.ReadLine();
                        Directory.CreateDirectory(folderName);
                        Console.Clear();
                        //Bu klasör ile ilgili bir işlem yapılabilir.
                        break;
                    case ConsoleKey.C:
                        Console.WriteLine("Güle güle :)");
                        return;
                }
            }

        }

        private static void FileOperations()
        {
            while (true)
            {
                Console.Clear();
                Menu("Dosya İşlemleri | Dos Uygulaması V 1.0", "(Y)eni Dosya", "(D)osyalar", "(G)eri");

                ConsoleKeyInfo keyInfo = Console.ReadKey(true);

                while (keyInfo.Key != ConsoleKey.G && keyInfo.Key != ConsoleKey.D && keyInfo.Key != ConsoleKey.Y)
                {
                    keyInfo = Console.ReadKey(true);
                }

                switch (keyInfo.Key)
                {
                    case ConsoleKey.Y:
                        Console.Write("Dosya Adı : ");
                        string fileName = Console.ReadLine();
                        File.Create(fileName).Close();
                        Console.Clear();
                        break;
                    case ConsoleKey.D:

                        Console.Clear();

                        Console.WriteLine(new String('-', 10));

                        DirectoryInfo currentDir = new DirectoryInfo(Directory.GetCurrentDirectory());

                        foreach (FileInfo file in currentDir.GetFiles())
                        {
                            Console.WriteLine($"{file.Name}\t{file.Length}\t{file.CreationTime}");
                        }

                        Console.WriteLine("Devam etmek için bir tuşa basınız");
                        Console.Read();

                        break;
                    case ConsoleKey.G:
                        Console.Clear();
                        return;
                }
            }
        }

        private static void Menu(string titleOrMessage, params string[] menus)
        {
            Console.WriteLine(titleOrMessage);
            int i = 1;
            foreach (string menu in menus)
                Console.WriteLine($"\t{i++} {menu}");
        }

        private static void KlasorIslemleriOrnek1()
        {
            DirectoryInfo notlarDir = Directory.CreateDirectory("Notlar");

            Directory.CreateDirectory("Notlar2");
            //Directory.Delete("Notlar2");

            File.WriteAllText("Notlar/Deneme.txt", "Merhaba ben deneme mesajı.");

            //Directory.Move("Notlar","Notlar2/Notlar");

            Directory.CreateDirectory(notlarDir.Name + "Ydk");
        }

        private static void DosyaIslemleriOrnek5()
        {
            string readFileName = "Okunan5.txt";
            string writeFileName = "Yazilan5.txt";

            //FileStream fileStreamReadFile = new FileStream(readFileName, FileMode.OpenOrCreate, FileAccess.ReadWrite);

            //string content = "Lorem ipsum dolor sit amet";
            //byte[] buffer = Encoding.UTF8.GetBytes(content);

            //fileStreamReadFile.Write(buffer, 0, buffer.Length);
            //fileStreamReadFile.Flush();
            //fileStreamReadFile.Close();

            FileStream fileStreamReadFile;

            if (!File.Exists(readFileName))
            {
                fileStreamReadFile = new FileStream(readFileName, FileMode.Create, FileAccess.Write);
                //File.Create(readFileName).Close();
                string content = "Lorem ipsum dolor sit amet";//, consectetur adipiscing elit. Mauris in sem convallis, sodales nisi at, maximus velit. Nam sit amet erat tortor. Aliquam sollicitudin purus vitae elementum convallis. Fusce a molestie orci. Praesent sit amet ex in nunc faucibus maximus ut quis felis. In viverra turpis eu fringilla dictum. Curabitur vehicula dui ac lectus faucibus ornare. Aenean libero ante, volutpat sed ullamcorper sit amet, maximus quis nisl. Aenean id vulputate dolor. Phasellus vestibulum, tortor vel tincidunt scelerisque, lorem metus porttitor elit, nec tristique ante nunc ut sapien. Aliquam erat volutpat. Praesent malesuada, tortor eu interdum eleifend, tortor mauris interdum orci, non molestie mi nunc nec mauris. Praesent cursus velit id ligula vestibulum consectetur.";
                //File.WriteAllText(readFileName, content);

                byte[] buffer = Encoding.UTF8.GetBytes(content);

                fileStreamReadFile.Write(buffer, 0, buffer.Length);
                fileStreamReadFile.Flush();
                fileStreamReadFile.Close();
            }

            fileStreamReadFile = new FileStream(readFileName, FileMode.Open, FileAccess.Read);


            FileStream fileStreamWriteFile = new FileStream(writeFileName, FileMode.OpenOrCreate, FileAccess.Write);

            StreamReader streamReader = new StreamReader(fileStreamReadFile);
            StreamWriter streamWriter = new StreamWriter(fileStreamWriteFile);

            //int readChar = streamReader.Read();

            //streamReader.Peek()

            //while(streamReader.Read() > 0)
            //while(streamReader.Peek() > 0)
            //while(!streamReader.EndOfStream)
            //{
            //    int readChar = streamReader.Read();
            //    //Console.Write((char)readChar);

            //    streamWriter.Write((char)readChar);

            //}

            int size = 10;
            char[] charbuffer = new char[size];

            int i = 0;
            int length = (int)streamReader.BaseStream.Length;
            int limit = new Random().Next(4, (length / size) - 1);

            while (!streamReader.EndOfStream)
            {
                int readChar = streamReader.ReadBlock(charbuffer, 0, size);
                streamWriter.WriteLine(charbuffer, 0, readChar);
                //streamWriter.Write(charbuffer, 0, readChar);

                if (i > limit)
                    break;

                i++;
            }
            streamWriter.Flush();
            /*
             * Lorem ipsum dolor sit amet
             * oe pu oo i mt
             * 
             */


        }

        private static void DosyaIslemleriOrnek4()
        {
            string readFileName = "Okunan4.txt";
            string writeFileName = "Yazilan4.txt";

            if (!File.Exists(readFileName))
            {
                //File.Create(readFileName).Close();
                string content = "Hello world today beautiful day";
                File.WriteAllText(readFileName, content);
            }

            //File.Open(readFileName, FileMode.Open, FileAccess.Read);
            //File.OpenRead(readFileName);

            //File.Open("ogrenciler.dat", FileMode.Append, FileAccess.Write);

            //File.Open(writeFileName, FileMode.OpenOrCreate, FileAccess.Write);
            //File.OpenWrite(writeFileName);

            FileStream fsReadFile = File.OpenRead(readFileName);

            StreamReader streamReader = new StreamReader(fsReadFile);

            #region StreamReader Read ile char ascii code adım adım okuma
            //int readChar = streamReader.Read();

            //while (readChar > 0)
            //{
            //    Console.Write((char)readChar);
            //    readChar = streamReader.Read();
            //} 
            #endregion

            #region Read metotunu while içinde direk kullanım hatası 
            //while (streamReader.Read() > 0)
            //{
            //    Console.Write((char)streamReader.Read());
            //} 
            #endregion

            #region StreamReader EndOStream ile okuma işlemi
            //string text = "";

            //while (!streamReader.EndOfStream)
            //{
            //    //Console.SetCursorPosition(0, 0);
            //    //Console.Write($"Position : {streamReader}");

            //    //Console.SetCursorPosition(0, 1);
            //    //text += (char)streamReader.Read();
            //    //Console.Write(text);

            //    Console.Write((char)streamReader.Read());

            //    Thread.Sleep(125);
            //} 
            #endregion

            #region StreamReader ReadToEnd ile tüm içeriği okumak
            //Console.WriteLine(streamReader.ReadToEnd());

            //Console.WriteLine(File.ReadAllText(readFileName)); 
            #endregion

            #region ReadBlock ile okuma
            //int size = 5;
            //char[] buffer = new char[size];


            //while(streamReader.ReadBlock(buffer, 0, size) > 0)
            //{
            //    Console.Write(new string(buffer));
            //    Thread.Sleep(1000);
            //} 
            #endregion

            #region StreamReader ReadLine ile okuma
            //while(!streamReader.EndOfStream)
            //    Console.WriteLine(streamReader.ReadLine()); 
            #endregion

        }

        private static void DosyaIslemleriOrnek3()
        {
            string readFileName = "Okunan.txt";
            string writeFileName = "Yazilan.txt";

            Note[] Mary ={
                new Note(Tone.B, Duration.QUARTER),
                new Note(Tone.A, Duration.QUARTER),
                new Note(Tone.GbelowC, Duration.QUARTER),
                new Note(Tone.A, Duration.QUARTER),
                new Note(Tone.B, Duration.QUARTER),
                new Note(Tone.B, Duration.QUARTER),
                new Note(Tone.B, Duration.HALF),
                new Note(Tone.A, Duration.QUARTER),
                new Note(Tone.A, Duration.QUARTER),
                new Note(Tone.A, Duration.HALF),
                new Note(Tone.B, Duration.QUARTER),
                new Note(Tone.D, Duration.QUARTER),
                new Note(Tone.D, Duration.HALF)
                };

            if (!File.Exists(readFileName))
            {
                //File.Create(readFileName).Close();
                string content = "Lorem ipsum dolor sit amet, consectetur adipiscing elit. Mauris in sem convallis, sodales nisi at, maximus velit. Nam sit amet erat tortor. Aliquam sollicitudin purus vitae elementum convallis. Fusce a molestie orci. Praesent sit amet ex in nunc faucibus maximus ut quis felis. In viverra turpis eu fringilla dictum. Curabitur vehicula dui ac lectus faucibus ornare. Aenean libero ante, volutpat sed ullamcorper sit amet, maximus quis nisl. Aenean id vulputate dolor. Phasellus vestibulum, tortor vel tincidunt scelerisque, lorem metus porttitor elit, nec tristique ante nunc ut sapien. Aliquam erat volutpat. Praesent malesuada, tortor eu interdum eleifend, tortor mauris interdum orci, non molestie mi nunc nec mauris. Praesent cursus velit id ligula vestibulum consectetur.";
                File.WriteAllText(readFileName, content);
            }

            FileStream fsRead = File.OpenRead(readFileName);
            FileStream fsWrite = File.OpenWrite(writeFileName);

            int size = 14;// new Random().Next(20,75);
            int offetset = size;
            byte[] buffer = new byte[size];

            int readByte = fsRead.Read(buffer, 0, size);

            int barLenght = (int)(fsRead.Length / size);

            string perChar = "";

            //while(readByte > 0)
            while (true)
            {
                #region Encoding UTF GetString metotunun çalışma prensibi
                //string tempText = "";

                //foreach(byte readingByte in buffer)
                //{
                //    tempText += (char)readingByte;
                //}

                //Console.WriteLine($"TempText : {tempText}"); 
                #endregion

                #region Byte byte ekran yazılan çalışma
                //string readText = Encoding.UTF8.GetString(buffer);

                //Console.WriteLine($"readText : {readText}");
                //Console.Write(readText); 
                #endregion

                Console.SetCursorPosition(0, 0);
                Console.Write($"Okunan / Boyut : {fsRead.Position} / {fsRead.Length}");

                Console.SetCursorPosition(0, 1);

                double percent = fsRead.Position * 1.0 / fsRead.Length * 1.0;

                Console.Write("");
                Console.Write($"%{Math.Round(percent * 100)}");

                Console.SetCursorPosition(0, 2);

                perChar += "\u2588";

                Console.ForegroundColor = ConsoleColor.Magenta;
                Console.BackgroundColor = ConsoleColor.White;
                Console.Write($"[{perChar}{new String(' ', barLenght - (perChar.Length - 1))}]");
                Console.ResetColor();

                fsWrite.Write(buffer, 0, size);

                //size = new Random().Next(20, 75);
                Array.Resize(ref buffer, size);

                fsWrite.Seek(offetset, SeekOrigin.Begin);
                fsRead.Seek(offetset, SeekOrigin.Begin);

                readByte = fsRead.Read(buffer, 0, size);

                if (readByte == 0)
                    break;

                Array.Resize(ref buffer, readByte);
                size = buffer.Length;

                offetset += readByte;

                // Declare the first few notes of the song, "Mary Had A Little Lamb".

                // Play the song
                Play(Mary);

                //Thread.Sleep(250);
            }
        }

        private static void DosyaIslemleriOrnek2()
        {
            /*
             * Dosya işlemleri nelerdir.
             * - Dosya oluşturmak
             * - Dosya silmek
             * - Dosya kopyalamak
             * - Dosya taşımak
             * - Dosya ya veri eklemek
             * - Dosya dan veri okumak
             */

            // Dosya oluşrmak için
            //File.Create("Deneme-1-29072024.txt");
            //File.Create("..\\Deneme-1-29072024.txt");
            //File.Create(@"..\..\..\Deneme-1-29072024.txt");

            // Dosyaya yazma
            string timestamp = DateTime.Now.ToString("ddMMyyyyHHmmss");

            string path = $@"C:\dosyalar\ank-18-{timestamp}.txt";

            #region File sınıfı ile tüm metni yazdırma işlemleri WriteAllText, WriteAllLines, WriteAllBytes
            // Full text yazım için kullanılır. Kaçış karakteri kullanabiliriz.
            //File.WriteAllText(path, "Bu mesajı tek seferde yazdık. \n\tBu yeni bir satır olmasını istediğim bir yazdır.");

            // Metin dizileri olarak satır satır yazılması için
            //string[] contents = { "1. Satır", "2. Satır", "3. Satır" };
            //File.WriteAllLines(path, contents);

            // Byte array olarak yazılması

            //byte[] test = Encoding.UTF8.GetBytes("HELLO ABC");
            //byte[] bytes = { 72, 69, 76, 76, 79, 32, 65, 66, 67 };
            //File.WriteAllBytes(path, bytes); 
            #endregion

            #region File sınıfı ile tüm metni okuma işlemleri, ReadAllText, ReadAllLines, ReadLines, ReadAllBytes

            path = $@"C:\dosyalar\ank-18-29072024.txt";

            //File.WriteAllText(path, "Merhaba dünya bugün hava çok güzel.\nYarın nasıl olur bilinmez.\"Bu yazı çift tırnak içindedir.\" \n Ben yeni bir satırda yazıldım. ");

            //string fileReadAllText = File.ReadAllText(path);

            //Console.WriteLine(fileReadAllText);

            //File.WriteAllLines(path, new string[] { "Merhaba", "Bu bir satır", "Bu da yeni bir satır" });

            //string[] fileReadAllLines = File.ReadAllLines(path);

            //foreach (string line in fileReadAllLines)
            //{
            //    Console.WriteLine(line);
            //}

            //Console.WriteLine("---------");

            //string fileReadAllText = File.ReadAllText(path);
            //Console.WriteLine(fileReadAllText);

            //List<string> linesList = File.ReadLines(path).ToList(); // List olarak kullanmak için bu metotu terich ederiz.

            //File.WriteAllText(path, "HELLO ABC");
            //byte[] bytes = File.ReadAllBytes(path);

            //foreach(byte b in bytes )
            //    Console.WriteLine(b);

            #endregion


            timestamp = DateTime.Now.ToString("ddMMyyyyHHmmss");
            path = $@"C:\dosyalar\ank-18-{timestamp}.txt";

            FileStream fs = File.Create(path);

            Console.WriteLine($"Can Read : {fs.CanRead}");
            Console.WriteLine($"Can Write : {fs.CanWrite}");
            Console.WriteLine($"Can Seek : {fs.CanSeek}");
            Console.WriteLine($"Can Timeout : {fs.CanTimeout}");
            Console.WriteLine($"Name : {fs.Name}");

            Console.WriteLine("------------");

            Console.WriteLine($"Name : {fs.Length}");

            Console.WriteLine("------------");


            //fs.WriteByte(65);
            //fs.WriteByte(66);
            //fs.WriteByte(67);

            #region WriteByte ile filestream dosya yazma
            //for (byte i = 65; i < 91; i++)
            //{
            //    fs.WriteByte(i);
            //}
            //fs.Flush();
            #endregion

            string text = "Merhaba bu yazi C# da console uygulmasindan yazildi.";

            byte[] bytes = Encoding.UTF8.GetBytes(text);

            for (int i = 1; i <= bytes.Length; i++)
            {
                if (i % 10 == 0)
                    Console.WriteLine((char)bytes[i - 1]);
                else
                    Console.Write((char)bytes[i - 1]);
            }

            int artanKarakterSayisi = bytes.Length % 10; // 2
            int toplamPaketSayisi = bytes.Length / 10; // 5

            for (int i = 0; i < toplamPaketSayisi; i++)
            {
                fs.Write(bytes, i * 10, 10);
                /*
                 * i = 0, 0 , 10
                 * i = 1, 10, 10
                 * i = 2, 20, 10
                 * i = 3, 30, 10
                 * i = 4, 40, 10
                 */
            }

            fs.Write(bytes, toplamPaketSayisi * 10, artanKarakterSayisi);

            fs.Close();

        }

        private static void DosyaIslemleriOrnek1()
        {

            #region Dosya yazma işlemleri ilk çalışma
            // Dosya yazma işlemi
            //Console.Write("Lütfen dosya ismini yazınız (Örn:deneme.txt) :");
            //string fileName = Console.ReadLine();

            //Console.Write("Lütfen dosya içeriğini yazınız : ");
            //string content = Console.ReadLine();

            ////File.Create(fileName).Close(); // FullPath vermez ise exe dosyasının olduğu yerde bu dosyayı oluşturacaktır.

            //File.WriteAllText(fileName, content); 
            #endregion

            #region File ile dosya yazma WriteAllText ve WriteAllLines metotları
            //string[] ogrenciler = new string[13];

            //for (int i = 0; i < ogrenciler.Length; i++)
            //{
            //    Console.Write("Lütfen öğrenci adını yazınız : ");
            //    ogrenciler[i] = Console.ReadLine();
            //}

            //File.WriteAllLines("1-" + fileName, ogrenciler);

            //Console.WriteLine("Yeni Kayıtlara geçiyoruz");

            //for (int i = 1; i <= 13; i++) 
            //{
            //    Console.Write("Lütfen öğrenci adını yazınız : ");
            //    string ogrenciAdi = Console.ReadLine();

            //    File.WriteAllText("2-" + fileName, ogrenciAdi + "\n");
            //} 
            #endregion

            #region FileInfo örnek çalışması
            //Console.Write("Lütfen bilgisini istediğiniz dosya ismini yazınız (Örn:deneme.txt) :");
            //string fileNameForInfo = Console.ReadLine();

            //FileInfo fileInfo = new FileInfo(fileNameForInfo);

            //Console.WriteLine($"Dosya Adı : {fileInfo.Name}");
            //Console.WriteLine($"Dosya Tam Adı : {fileInfo.FullName}");
            //Console.WriteLine($"Dosya var mı?: {fileInfo.Exists}");
            //Console.WriteLine($"Dosya Oluşturma Zamanı : {fileInfo.CreationTime}");
            //Console.WriteLine($"Dosya Klasörü : {fileInfo.DirectoryName}");
            //Console.WriteLine($"Dosya uzantısı : {fileInfo.Extension}");
            //Console.WriteLine($"Dosya Sadece Okunabilir mi? : {fileInfo.IsReadOnly}");
            //Console.WriteLine($"Dosya Son Erişim Zamanı : {fileInfo.LastAccessTime}");
            //Console.WriteLine($"Dosya Son Yazma(Değiştirme) Zamanı : {fileInfo.LastWriteTime}");
            //Console.WriteLine($"Dosya boyutu : {fileInfo.Length}");

            //FileAttributes fileAttributes = fileInfo.Attributes;
            //DirectoryInfo directoryInfo = fileInfo.Directory; 
            #endregion

            #region Klasör işlemleri ilk çalışma

            //Directory.CreateDirectory("Ank18"); // exe dosyasını (Console uygulamasının çalıştırılabilir dosyası) bulunduğu yere oluşturur.
            //Directory.CreateDirectory("Caslimalar\\Ank18\\Introduction");
            //Directory.CreateDirectory(@"Workshop\Ank18\Introduction");
            //Directory.CreateDirectory(@"C:\Ank18\Calismalar\26072024");

            #endregion

            #region Klasör info sınıfı, Dosya ve Klasör Taşıma, Kopyalama ve Silme işlemleri

            string currentDirectory = Directory.GetCurrentDirectory();

            DirectoryInfo directoryInfo = new DirectoryInfo(currentDirectory);

            Console.WriteLine(directoryInfo.Name);

            foreach (DirectoryInfo directory in directoryInfo.GetDirectories())
            {
                Console.WriteLine($"\t{directory.Name}");
            }

            foreach (FileInfo file in directoryInfo.GetFiles())
            {
                Console.WriteLine($"\t{file.Name}");
            }

            string fileName = "";
            string folderName = "";
            string sourceFolderName = "";
            string destFolderName = "";

            #region Dosya Kopyalama işlemi
            //Console.Write("Kopyalamak istediğiniz dosyanın adını yazını : ");
            //fileName = Console.ReadLine();

            //if (!File.Exists(fileName))
            //{
            //    Console.WriteLine("Dosyanız bulunamadı. İşlem sonlandırıldı.");
            //    return;
            //}

            //Console.Write("Hedef klasörü yazınız : ");
            //folderName = Console.ReadLine();

            //if (!Directory.Exists(folderName))
            //{
            //    Console.WriteLine("Klasör bulunamadı. İşlem sonlandırıldı.");
            //    return;
            //}

            //File.Copy(fileName, folderName + "/" + fileName, true); 
            #endregion

            #region Dosya Silme İşlemi
            //Console.Write("Silmek istediğiniz dosyanın adını yazını : ");
            //fileName = Console.ReadLine();

            //if (!File.Exists(fileName))
            //{
            //    Console.WriteLine("Dosyanız bulunamadı. İşlem sonlandırıldı.");
            //    return;
            //}

            //File.Delete(fileName); 
            #endregion

            #region Dosya Move İşlemi
            //Console.Write("Taşımak istediğiniz dosyanın adını yazını : ");
            //fileName = Console.ReadLine();

            //if (!File.Exists(fileName))
            //{
            //    Console.WriteLine("Dosyanız bulunamadı. İşlem sonlandırıldı.");
            //    return;
            //}

            //Console.Write("Hedef klasörü yazınız : ");
            //folderName = Console.ReadLine();

            //if (!Directory.Exists(folderName))
            //{
            //    Console.WriteLine("Klasör bulunamadı. İşlem sonlandırıldı.");
            //    return;
            //}

            ////FileInfo fileInfo = new FileInfo(fileName); // 1-26072024-ornek1.txt => 1-26072024-ornek1-26072024104323.txt
            //// fileName = "1-26072024-ornek1.txt";

            //string[] fileNameSplit = fileName.Split('.');

            //string newFileName = $"{fileNameSplit[0]}-{DateTime.Now.ToString("ddMMyyyyHHmmss")}.{fileNameSplit[1]}";

            //File.Move(fileName, folderName + "/" + newFileName); 
            #endregion

            #region Recursive Dosya kopyalama işlemi
            Console.Write("Kopyalamak istediğini klasörü yazınız : ");
            sourceFolderName = Console.ReadLine();

            if (!Directory.Exists(sourceFolderName))
            {
                Console.WriteLine("Klasör bulunamadı. İşlem sonlandırıldı.");
                return;
            }

            Console.Write("Hedef klasörü yazınız : ");
            destFolderName = Console.ReadLine();

            //if (!Directory.Exists(destFolderName))
            //{
            //    Console.WriteLine("Klasör bulunamadı. İşlem sonlandırıldı.");
            //    return;
            //}

            string sourceDirectoryPath = Path.GetFullPath(sourceFolderName);
            //string sourceDirectoryPath2 = Path.Combine(Directory.GetCurrentDirectory(), sourceFolderName, "YeniFolder", "Çalışmalar");
            DirectoryInfo soruceDirectoryInfo = new DirectoryInfo(sourceDirectoryPath);

            string destDirectoryPath = Path.GetFullPath(destFolderName);
            DirectoryInfo destDirectoryInfo = new DirectoryInfo(destDirectoryPath);

            CopyTo(soruceDirectoryInfo, destDirectoryInfo);
            #endregion


            // Folder 

            #region Klasör ve Dosya kopyalama ilk seviye işlem olarak örnek
            //string destPath = destFolderName + "/" + folderName;

            //Directory.CreateDirectory(destPath);

            //directoryInfo = new DirectoryInfo(folderName);

            //foreach (FileInfo file in directoryInfo.GetFiles())
            //{
            //    //File.Copy(folderName + "/" + file.Name, destPath + "/" + file.Name);
            //    File.Copy(file.FullName, destPath + "/" + file.Name);
            //}

            //foreach (DirectoryInfo directory in directoryInfo.GetDirectories())
            //{
            //    string newDestPath = destPath + "/" + directory.Name;
            //    Directory.CreateDirectory(newDestPath);
            //} 
            #endregion

            #endregion

            /*
             * 10 karakter => 1 karakter 8 Bit => 1 Byte => 10 karakter 10 Byte
             */

            //string fileread = File.ReadAllText("ank18test.txt");
            //Console.WriteLine(fileread);

        }

        private static void CopyTo(DirectoryInfo soruceDirectoryInfo, DirectoryInfo destDirectoryInfo)
        {
            if (!Directory.Exists(destDirectoryInfo.FullName))
                Directory.CreateDirectory(destDirectoryInfo.Name);


            foreach (FileInfo file in soruceDirectoryInfo.GetFiles())
            {
                //file.Name;
                //destDirectoryInfo.FullName

                file.CopyTo(Path.Combine(destDirectoryInfo.FullName, file.Name), true);

            }

            foreach (DirectoryInfo directory in soruceDirectoryInfo.GetDirectories())
            {
                DirectoryInfo subDirInfo = directory;
                DirectoryInfo destSubDirectoryInfo = destDirectoryInfo.CreateSubdirectory(subDirInfo.Name);
                CopyTo(subDirInfo, destSubDirectoryInfo);
            }

        }


        // Play the notes in a song.
        protected static void Play(Note[] tune)
        {
            foreach (Note n in tune)
            {
                if (n.NoteTone == Tone.REST)
                    Thread.Sleep((int)n.NoteDuration);
                else
                    Console.Beep((int)n.NoteTone, (int)n.NoteDuration);
            }
        }

        // Define the frequencies of notes in an octave, as well as
        // silence (rest).
        protected enum Tone
        {
            REST = 0,
            GbelowC = 196,
            A = 220,
            Asharp = 233,
            B = 247,
            C = 262,
            Csharp = 277,
            D = 294,
            Dsharp = 311,
            E = 330,
            F = 349,
            Fsharp = 370,
            G = 392,
            Gsharp = 415,
        }

        // Define the duration of a note in units of milliseconds.
        protected enum Duration
        {
            WHOLE = 1600,
            HALF = WHOLE / 2,
            QUARTER = HALF / 2,
            EIGHTH = QUARTER / 2,
            SIXTEENTH = EIGHTH / 2,
        }

        // Define a note as a frequency (tone) and the amount of
        // time (duration) the note plays.
        protected struct Note
        {
            Tone toneVal;
            Duration durVal;

            // Define a constructor to create a specific note.
            public Note(Tone frequency, Duration time)
            {
                toneVal = frequency;
                durVal = time;
            }

            // Define properties to return the note's tone and duration.
            public Tone NoteTone { get { return toneVal; } }
            public Duration NoteDuration { get { return durVal; } }
        }

    }
}
