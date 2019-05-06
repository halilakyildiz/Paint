using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApp1
{
    
    public partial class Form1 : Form
    {

        public int sayi = 0;
        public int tiklananyer_x;
        public int tiklananyer_y;
        int secili;
        public int renksecimi;
        bool cizimAktifmi = false;
        int maxkaresayisi = 0;

        Sekil[] sekiller;
        Kare Karem = new Kare();
        Ucgen Ucgenim = new Ucgen();
        Altigen altigenim = new Altigen();

        public int karesayisi = 0;
        Daire Dairem = new Daire();

        public Form1()
        {
            InitializeComponent();
        }
        
        private void Form1_Load(object sender, EventArgs e)
        {
            DoubleBuffered = true;
            

            sekiller = new Sekil[maxkaresayisi];
           
           

            Height = 600;
            Width = 1000;

            Paint += AnaPencerem_Paint;

            

    
            
            MouseDown += AnaPencerem_MouseDown;
            MouseMove += AnaPencerem_MouseMove;
            MouseUp += AnaPencerem_MouseUp;
                
        }

      
        private void AnaPencerem_MouseUp(object sender, MouseEventArgs e)
        {
            cizimAktifmi = false;
            if (secili == 0)
            {
                Array.Resize(ref sekiller, sekiller.Length + 1);//Dizinini boyutunu bir arttırıyor ve dizi sonsuz gibi oluyor.
                sekiller[sekiller.Length - 1] = Karem;//Nesneyi diznin bir önceki elemanına atıyor.
                sekiller[karesayisi] = Karem;
                karesayisi++;
            }
            if (secili == 1)
            {
                Array.Resize(ref sekiller, sekiller.Length + 1);
                sekiller[sekiller.Length - 1] = Dairem;
                sekiller[karesayisi] = Dairem;
                karesayisi++;
            }
            if(secili==2)
            {
                Ucgenim.width = Ucgenim.x3 - Ucgenim.x1;
                Ucgenim.height = Ucgenim.y1 - Ucgenim.y2;
                Array.Resize(ref sekiller, sekiller.Length + 1);
                sekiller[sekiller.Length - 1] = Ucgenim;
                sekiller[karesayisi] = Ucgenim;
                karesayisi++;
            }
            if(secili==3)
            {
                altigenim.height = altigenim.y2 - altigenim.y6;
                altigenim.width = altigenim.x4 - altigenim.x1;
                Array.Resize(ref sekiller, sekiller.Length + 1);
                sekiller[sekiller.Length - 1] = altigenim;
                sekiller[karesayisi] = altigenim;
                karesayisi++;
            }

            Invalidate();
        }

        private void AnaPencerem_MouseMove(object sender, MouseEventArgs e)
        {
           if(e.X==700 || e.Y == 600) { cizimAktifmi = false; } // Çizim alanın dışına taşmaması için kontrol ediyor.
            if (secili == 0) // secili 0 ise karem nesnesi için giriyor.
                    {
                        if (cizimAktifmi)
                        {
                            Karem.width = e.X - Karem.X;
                    
                        }
                    }
                    if (secili == 1) // secili 1 ise dairem nesnesi için.
                    {
                        if (cizimAktifmi)
                        {
                       
                        Dairem.width = e.X - Dairem.X;


                        }
                    }
                    if (secili == 2) //secili 2 ise üçgenim
                    {
                        if (cizimAktifmi)
                        {
                           
                            Ucgenim.x1 = tiklananyer_x;
                            Ucgenim.y1 = e.Y;
                            Ucgenim.x2 = e.X - ((Ucgenim.x3 - Ucgenim.x1) / 2); // üçgen içinde altıgen deki mantığı yaptım.
                            Ucgenim.y2 = tiklananyer_y;
                            Ucgenim.x3 = e.X;
                            Ucgenim.y3 = e.Y;
                        }
                    }
                    if (secili == 3) // secili 3 ise altıgenim
                    {
                        if (cizimAktifmi)
                        {
                            
                            altigenim.x1 = tiklananyer_x;
                            altigenim.y1 = e.Y - ((altigenim.y2 - altigenim.y6) / 2);
                            altigenim.x2 = altigenim.x1 + ((altigenim.x3 - altigenim.x1) / 3);
                            altigenim.y2 = e.Y;
                            altigenim.x3 = e.X;
                            altigenim.y3 = e.Y;
                            altigenim.x4 = e.X + ((altigenim.x3 - altigenim.x1) / 3);                   // Altıgenin noktalarının mousenin hareketine göre konumlanması için veirler girdim.
                            altigenim.y4 = e.Y - ((altigenim.y3 - altigenim.y5) / 2);                   // Bu değerleri ben kendim hesplayrarkak yazdım.
                            altigenim.x5 = e.X;
                            altigenim.y5 = tiklananyer_y;
                            altigenim.x6 = altigenim.x1 + ((altigenim.x3 - altigenim.x1) / 3);
                            altigenim.y6 = tiklananyer_y;
                        }
                    }
        
            Invalidate();
        }
        int secilenrenk;
        // değişkenin değerine göre mouse tıklandığıdna o seçilen nesneyi oluşturuyor ve rengini nenseye paramtere oalrark veriyor.
        private void AnaPencerem_MouseDown(object sender, MouseEventArgs e)
        {
            cizimAktifmi = true;
            if (secili == 0) 
            {
                Karem = new Kare();
                Karem.Renk(secilenrenk);
                
                Karem.X = e.X;
                Karem.Y = e.Y;
            }
            if (secili == 1)
            {
                Dairem = new Daire();
                Dairem.Renk(secilenrenk);
                
                Dairem.X = e.X;
                Dairem.Y = e.Y;
            }
            if (secili == 2)
            {
                Ucgenim = new Ucgen();
                Ucgenim.Renk(secilenrenk);
                tiklananyer_x = e.X;
                tiklananyer_y = e.Y;

                
            }
            if(secili==3)
            {
                altigenim = new Altigen();
                altigenim.Renk(secilenrenk);
                tiklananyer_x = e.X;
                tiklananyer_y = e.Y;
            }
            if(secili==4)
            {
                x = e.X;
                y = e.Y;
            }

            

            Invalidate();
        }
        SolidBrush brush = new SolidBrush(Color.Black);

        private void AnaPencerem_Paint(object sender, PaintEventArgs e)
        {        
            Graphics cizimaraci1 = e.Graphics;
            SolidBrush brush = new SolidBrush(Color.Bisque);
            Rectangle rect = new Rectangle(0, 0, 700, 600);
            cizimaraci1.FillRectangle(brush, rect);

            if (secili == 0)
            {
                Karem.Ciz(cizimaraci1,e);
            }
            if (secili == 1)
            {
                Dairem.Ciz(cizimaraci1,e);            // Hngi nesne seçilisye ona girip çiziyor.
            }
            if (secili == 2)
            {               
                Ucgenim.Ciz(cizimaraci1,e);
            }
            if (secili == 3)
            {
                altigenim.Ciz(cizimaraci1,e);
            }



            for (int i = 0; i < karesayisi; i++)
            {
                if(sekiller[i]!=null)
                sekiller[i].Ciz(cizimaraci1, e);
            }




            

            Text = x.ToString() + "," +y.ToString();
        }

        private void button12_Click(object sender, EventArgs e) // Butonlarl nesne seçiiyor ve seçilen nesneye göre değişkene değer atıyor.
        {
            secili = 0;
        }

        private void button13_Click(object sender, EventArgs e)
        {
            secili = 1;
        }

        private void button14_Click(object sender, EventArgs e)
        {
            secili = 2;
        }

        private void button15_Click(object sender, EventArgs e)
        {
            secili = 3;
        }

        private void button7_Click(object sender, EventArgs e)  // Burda da renk atanıyor.
        {           
            secilenrenk = 7;
          

        }

        private void button1_Click(object sender, EventArgs e)
        {
           
            secilenrenk = 1;



        }

        private void button2_Click(object sender, EventArgs e)
        {
          
            secilenrenk = 2;


        }
       
        private void button3_Click(object sender, EventArgs e)
        {
            
            secilenrenk = 3;
        }

        private void button4_Click(object sender, EventArgs e)
        {
           
            secilenrenk = 4;
        }

        private void button5_Click(object sender, EventArgs e)
        {
          
            secilenrenk = 5;
        }

        private void button6_Click(object sender, EventArgs e)
        {
            
            secilenrenk = 6;
        }

        private void button8_Click(object sender, EventArgs e)
        {
            secilenrenk = 8;
        }

        private void button9_Click(object sender, EventArgs e)
        {
            
            secilenrenk = 9;
        }

        int x; // Farenin silmek için tıkadığı yerin x ve y kordinatlarını tutacak değişken
        int y;
        int secilensekil_x; // Silinecek şeklin dizideki index i.
        int secilensekil_y;
        bool esit = false;
        private void button10_Click_1(object sender, EventArgs e) // Nesne seçme butonu tıklanınca secili 4 atanıyor ki nesne çizilmesin
        {
            secili = 4;
        }
        private void button11_Click_1(object sender, EventArgs e) // sil butonu tıklanıyor
        {

            SekilBul(); // Method çağrılıyor method içinde seçilen şekil değişkene atanıyor.
           if(esit) // seçilen şekil siliniyor.
           // sekiller[secilensekil_x] = null; 
            sekiller[secilensekil_x].width = 0;   // Silme işlemini kordinatları 0 layarak yaptım. null deyince silinen şekli tekrar çiziyor.
        } 

        private void SekilBul()
        {
          
            
            for (int i = 0; i < sekiller.Length; i++)
            {
                int genislik = 0; // Nesnenin width değerini tutacak
                int yukseklik = 0; // Nesnenin height derini tutacak
                if (sekiller[i] != null) // Dizieki eleman boş değilse girecek
                {
                    genislik = sekiller[i].width; // Nesnenin width değeri atanıyor
                    yukseklik = sekiller[i].height; // Nesnenin height değei atanıyor

                    int k = sekiller[i].X; //Nesnenin X kordinatı atanıyor
                    int m = sekiller[i].Y; // Nesnein Y kordinatı atanıyor

                    int j = 0;
                    while (genislik!=0) // Genişlik 1 er azalarak gidecek 0 oluncaya kadar devam edecek.
                    {
                        if(x == (k + j)) // Nesnenin X korinatından başlayıp genişlik kadar birer artarak giecdek
                        {
                            secilensekil_x = i;// Farenin tıkladığı yerin X kordinatı ile k uyuşuyor ise nesne atanıyor.
                        }
                        j++;
                        genislik--;
                    }
                    int z = 0;
                    while (yukseklik != 0)  // Yukarıdakinin aynısı yükseklik içinde geçerli.
                    {

                        if (  y == (m + z))
                        {
                            secilensekil_y = i;
                        }
                        z++;
                        yukseklik--;
                    }
                    
                


                }
            }
            if (secilensekil_x == secilensekil_y) // İkik nesne birbirine eşit ise nesne seçilmiş oluyor ve değişkene atanıyor.
                esit = true;
           

            
        }
        private void label3_Click(object sender, EventArgs e)
        {

        }

       
    }
}
