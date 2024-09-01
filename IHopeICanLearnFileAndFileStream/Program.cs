using System.ComponentModel;
using System.Diagnostics.Metrics;
using System.IO;
using System.Runtime.ConstrainedExecution;
using System.Security.Cryptography;
using System.Text;

namespace IHopeICanLearnFileAndFileStream
{
    internal class Program
    {
        static void Main(string[] args)
        {

            FileCalisma();
            //FileStreamCalisma();

            

        }

        private static void FileStreamCalisma()
        {


            //Name of the File: Dosyanın adı veya tam yolu.
            //(FileName.txt, @”C:\Users\Username\Documents\FileName.txt”)


            //FileMode: Dosyanın açılış modu. (Open(Mevcut dosyayı açma), Create(Yeni bir dosya oluştur),
            //OpenOrCreate(Varsa aç yoksa oluştur), Append(Mevcut dosyayı aç ve sonuna bilgi ekle),
            //Truncate(Mevcut dosyayı aç boyutunu sıfır yap.)


            //FileAccess: Dosyanın erişimi. (Read, Write, ReadWrite)


            //FileShare: Bu belirli dosyaya diğer FileStream nesnelerine erişimi belirtir.
            //(None(Dosya paylaşma), Read(Okumasına izin ver), Write(Yazılmasına izin ver),
            //ReadWrite(Okunabilir / Yazılabilir), Delete(Silinmesine izin ver),
            //Inheritable(Devir alınabilir.)



            Console.WriteLine("okuyorum");
            Console.WriteLine("----------");

            string readFileName = "Menu okuyorum.txt";
            string path = Path.GetTempFileName();
            Console.WriteLine(path);

            FileStream fileStreamReadFile = new FileStream(readFileName, FileMode.OpenOrCreate, FileAccess.ReadWrite);

            string content = "Yiyecekler içecekler";  //Bunlar okundu
            byte[] buffer = Encoding.UTF8.GetBytes(content);

            fileStreamReadFile.Write(buffer, 0, buffer.Length);
            fileStreamReadFile.Flush();
            fileStreamReadFile.Close();

            fileStreamReadFile = new FileStream(readFileName, FileMode.Create, FileAccess.Write);

            content = "Yiyecekler içecekler";
            byte[] buffer2 = Encoding.UTF8.GetBytes(content);

            fileStreamReadFile.Write(buffer2, 0, buffer2.Length);
            fileStreamReadFile.Flush();
            fileStreamReadFile.Close();


            string writeFileName = "Menu yaziyorum.txt";
           
            
            //bunu exe dosyasının içine yaptı


            


            fileStreamReadFile.Write(buffer, 0, buffer.Length);  //burda okuduğum yazıldı
            var x = fileStreamReadFile.Read(buffer, 0, 3);
               
        
            fileStreamReadFile.Flush();
            fileStreamReadFile.Close();

            Console.WriteLine("-------------");

            Console.WriteLine("yazıyorum");
            Console.WriteLine("----------");

            FileStream fileStreamWriteFile = new FileStream(writeFileName, FileMode.OpenOrCreate, FileAccess.ReadWrite);

            string content2 = "Yiyecekler içecekler";
            byte[] buffer2 = Encoding.UTF8.GetBytes(content);

            fileStreamWriteFile.Write(buffer, 0, buffer.Length); //burda sadece yazıldı.
            fileStreamWriteFile.Flush();
            fileStreamWriteFile.Close();

            Console.WriteLine(Encoding.UTF8.GetString(buffer2)); //system[]byte yazıyor niye???

            foreach (byte bufferByte in buffer2)
            {
                Console.WriteLine((char)bufferByte);
            }


            Console.WriteLine("----Stream Reader----");
            //Close(): StreamReader nesnesinin akışını kapatır.
            //Peek(): Bir sonraki kullanılabilir karakteri döndürür.Yoksa - 1 döndürür.
            //Read(): Karakter karakter okuma yapar. Okuma yapacak karakter yoksa -1 döndürür.
            //ReadLine(): Bir karakter satırı okur ve string olarak döndürür.Karakter okumanın sonuna geldiğinde null döndürür.
            //Seek(): Dosyadan belirli bir yerinde okumak / yazmak için kullanılır.
            //
            //
            //     Özellikler:

            //CurrentEncoding: StreamReader nesnesinin kullandığı geçerli karakter kodlamasını alır.

            //EndOfStream: Geçerli akış konumunun sonunda olup olmadığını gösteren bir değer alır.

            //BaseStream: Altta yatan stream döndürür.


            StreamReader streamReader = new StreamReader(readFileName);

            streamReader.BaseStream.Seek(10, SeekOrigin.Begin);

            

            while (streamReader.EndOfStream != true)
            {
                Console.WriteLine(streamReader.ReadLine());
            }
            streamReader.Close();

            
            Console.WriteLine("----Stream Writer----");


            //Close(): StreamReader nesnesinin akışını kapatır.
            //Flush(): Arabelleklerdeki verileri temizler ve arabelleğe alınan tüm verilerin alttaki akışa yazılmasına neden olur.
            //Write(): Akışa veri yazar.
            //WriteLine(): Write() ile aynıdır, ancak verilerin sonunda satır başı yapar.
            //Dispose(): StreamWriter tarafından kullanılan yönetilmeyen kaynakları serbest bırakır.
            //Özellikler:

            //AutoFlash: System.IO.StreamWriter.Write(System.Char) öğesine yapılan her çağrıdan sonra StreamWriter’ın arabelleğini temel alınan akışa boşaltıp temizlemeyeceğini gösteren bir değer alır.
            //Encoding: Çıktının yazıldığı System.Text.Encoding’i alır.

            //StreamWriter streamWriter = new StreamWriter(readFileName);

            //streamWriter.WriteLine("ABC");
            //streamWriter.WriteLine("DEF");
            ////Bura düz yazdı. bide byte byte yazdırıcam.

            //if(File.Exists(writeFileName))
            //{

            //}

            //streamWriter.Close();
        }

        private static void FileCalisma()
        {
            //File FileStream;

            /*Şimdi BArestaurant adında bi soya açıyoruz ve içine konuk listesi yerleştiriyoruz.
             * sonra burdan bi şekilde devam ederiz. İnfo olarak file filestream altındaki özellikleri ekle.
             */

            //File.AppendText
            //File.Create
            //File.CreateText
            //File.Delete
            //File.Exists
            //File.Move
            //File.Copy
            //File.ReadAllBytes
            //File.ReadAllLines
            //File.ReadAllText
            //File.WriteAllBytes
            //File.WriteAllLines
            //File.WriteAllText
            //File.OpenRead
            //File.OpenWrite

            



            File.Create(@"C:\Users\HP\Desktop\menu.txt").Close(); //Burda dosyayı oluşturdum. Kapatmak lazım.

            string fileName = Path.GetTempFileName();  //adresi atadım

            Console.WriteLine(fileName);

            string path = @"C:\Users\HP\Desktop\menu.txt"; //tanımlama

            string[] lines = { "Yiyecek Menüsü", "İçecek Menüsü" }; //tanımlama


            File.WriteAllText(path, "Yiyecek Menüsü"); //içerik yazdım 

            File.WriteAllLines(path, lines); // yine yazdım ama ilki silindi manuel ekledim.??

            //ByteYazdir(path);  Bunu açınca menü gidecek byte byte metin gelecek.

            Console.WriteLine("----------");

            File.ReadAllText(path);

            string fileRead = File.ReadAllText(path); //hepsini okudum ve atadım.

            Console.WriteLine("----------");

            Console.WriteLine(fileRead);

            string[] readLine = File.ReadAllLines(path); //burdada hepsini line line okudum
            foreach (var item in readLine)
            {
                Console.WriteLine(item);
            }

            Console.WriteLine("----------");

            byte[] bytes = File.ReadAllBytes(path);  //byte byte okumayı henüz yapamadım.

            Console.WriteLine(Encoding.UTF8.GetString(bytes));

            //for (int i = 0; i < bytes.Length; i++)
            //{

            //}

            Console.WriteLine("----------");

            File.Copy(path, @"C:\Users\HP\Desktop\menuyedek.txt"); //içerik gelmedi??

            string newPath = (@"C:\Users\HP\Desktop\menuyedek.txt");

            //File.Delete(path); Buna bakıcam 

            //File.Move(newPath, @"C:\Users\HP\Desktop\\menuydkydk.txt"); //bunu yaptığımda menuydk üstteki menuydkydk e taşınıyor.

            Console.WriteLine("----------");

            if (File.Exists(fileName))
            {
                Console.WriteLine("Dosya var");
            }

            Console.WriteLine("----------");


            FileInfo fileInfo = new FileInfo(newPath);

            Console.WriteLine(fileInfo.FullName);
            Console.WriteLine(fileInfo.Name);
            Console.WriteLine(fileInfo.CreationTime);
            Console.WriteLine(fileInfo.Length);
            Console.WriteLine(fileInfo.Exists);
            Console.WriteLine(fileInfo.LastWriteTime);

            Console.WriteLine("----------"); 

            //File.CreateText(newPath);

            Console.WriteLine("Burda şimdilik File ile işimiz bitti");
        }

        private static void ByteYazdir(string path)
        {
            byte[] text = Encoding.UTF8.GetBytes("bu byte byte yazıldı menü gitti"); //Bunu önce kapa sonra aç.

            File.WriteAllBytes(path, text);
        }
    }
}
