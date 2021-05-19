using System;
using System.Collections.Generic;

using System.Drawing;

using System.Windows.Forms;
using System.IO;
using System.Diagnostics;
using System.Globalization;
using System.Data.SQLite;
using Microsoft.EntityFrameworkCore.Sqlite;
using System.Linq;
using System.Text;
using Microsoft.EntityFrameworkCore;

namespace Diet_note
{

    public partial class Main : Form
    {
        public Main()
        {


            InitializeComponent();
 
            using(var db = new Aplicatincontext())
            {
              
                NamelistBox.Items.AddRange(db.Users.Include(e => e.Edges).Include(h => h.Histories).ToArray()); 
                EatBox1.Items.AddRange(db.Elements.ToArray());
                EatBox2.Items.AddRange(db.Elements.ToArray());
                EatBox3.Items.AddRange(db.Elements.ToArray());
                EatBox4.Items.AddRange(db.Elements.ToArray());
                EatBox5.Items.AddRange(db.Elements.ToArray());
                EatBox6.Items.AddRange(db.Elements.ToArray());
                _elements = db.Elements.ToList();

            }
           
                NamelistBox.DisplayMember = "Name";
                EatBox1.DisplayMember = "Name";
                EatBox2.DisplayMember = "Name";
                EatBox3.DisplayMember = "Name";
                EatBox4.DisplayMember = "Name";
                EatBox5.DisplayMember = "Name";
                EatBox6.DisplayMember = "Name";
                

        }

        readonly List<Energoelements> _elements = new List<Energoelements>();
        private void Historybutton_Click(object sender, EventArgs e)
        {
            if (NamelistBox.SelectedItem == null)
            {
                MessageBox.Show("Выберите пользователя!");
                return;
            }
            
            Size = new Size(276, 267);
            Panel historypanel = new Panel
            {
                Size = new Size(262,230),
                Location = new Point(0)
            };
            Controls.Add(historypanel);
            historypanel.BringToFront();

            Button historybutton = new Button
            {
                Size = new Size(262,30),
                Location = new Point(-1,198),
                Text = "Закрыть историю"

            };
            historypanel.Controls.Add(historybutton);
            
            ListBox historylistbox = new ListBox
            {
                DisplayMember = "h.Key",
                Size = new Size (62,200),
                Location = new Point(0)

            };
            historypanel.Controls.Add(historylistbox);

            TextBox historytextbox = new TextBox
            {
                Size = new Size(200, 199),
                Location = new Point(63, 0),
                Multiline = true,
                ScrollBars = ScrollBars.Both,
                TextAlign = HorizontalAlignment.Left,
                ReadOnly = true,
                BorderStyle = BorderStyle.Fixed3D
                
                
            };
            historypanel.Controls.Add(historytextbox);
           
            User seluser = (User)NamelistBox.SelectedItem;
            var Grouped = from history in seluser.Histories
                          group history by history.Date;
            foreach(IGrouping<DateTime,History> h in Grouped)
            {
                historylistbox.Items.Add(h);
   
            }
            List<string> lines = new List<string>();
            historybutton.Click += Closeclick;
            void Closeclick(object button, EventArgs click)
            {
                Size = new Size(890, 430);
                historypanel.Dispose();
       
            }
            historylistbox.SelectedIndexChanged += SelectDate;
            void SelectDate(object history, EventArgs click)
            {
                lines.Clear();
               
                foreach (IGrouping<DateTime,History> h in Grouped)
                {
                    if(h.Key.ToString()==historylistbox.Text)
                    {
                       
                        foreach (var t in h)
                        {
                            lines.AddRange(new string[] { $"Прием пищи: {t.Countofeat} из {seluser.Edges.Numbereats}", $"Что покушали: { t.Foodname}", $"Углеводы: { t.CarboHydrates}  из { seluser.Edges.Carbohydrates}", $"Белки: {t.Proteins} из {seluser.Edges.Proteins}", $"Жиры: {t.Fats} из {seluser.Edges.Fats}", $"Каллории: {t.Callories} из {seluser.Edges.Calloriesedge}","","" });
                            
                            historytextbox.Lines = lines.ToArray();
                        }
                    }

                }
                
            }
           
        }

        private void EatBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            EatBox1.Focus();
            try
            {
                Energoelements element = (Energoelements)EatBox1.SelectedItem;
                Ugllabel1.Text = element.Carbohydrates;
                Bellabel1.Text = element.Protein;
                Jirlabel1.Text = element.Fats;
                Callabel1.Text = element.Callories;
                AllUgllabel.Text = (Convert.ToDecimal(Ugllabel1.Text) + Convert.ToDecimal(Ugllabel2.Text) + Convert.ToDecimal(Ugllabel3.Text) + Convert.ToDecimal(Ugllabel4.Text) + Convert.ToDecimal(Ugllabel5.Text) + Convert.ToDecimal(Ugllabel6.Text)).ToString();
                AllBellabel.Text = (Convert.ToDecimal(Bellabel1.Text) + Convert.ToDecimal(Bellabel2.Text) + Convert.ToDecimal(Bellabel3.Text) + Convert.ToDecimal(Bellabel4.Text) + Convert.ToDecimal(Bellabel5.Text) + Convert.ToDecimal(Bellabel6.Text)).ToString();
                AllJirlabel.Text = (Convert.ToDecimal(Jirlabel1.Text) + Convert.ToDecimal(Jirlabel2.Text) + Convert.ToDecimal(Jirlabel3.Text) + Convert.ToDecimal(Jirlabel4.Text) + Convert.ToDecimal(Jirlabel5.Text) + Convert.ToDecimal(Jirlabel6.Text)).ToString();
                AllCallabel.Text = (Convert.ToDecimal(Callabel1.Text) + Convert.ToDecimal(Callabel2.Text) + Convert.ToDecimal(Callabel3.Text) + Convert.ToDecimal(Callabel4.Text) + Convert.ToDecimal(Callabel5.Text) + Convert.ToDecimal(Callabel6.Text)).ToString();
            }
            catch(Exception)
            {
                MessageBox.Show("Ошибка в данных блюда! Проверьте правильность информации!");
            }
        }

        private void EatBox2_SelectedIndexChanged(object sender, EventArgs e)
        {
            EatBox2.Focus();
            try
            {
                Energoelements element = (Energoelements)EatBox2.SelectedItem;
                Ugllabel2.Text = element.Carbohydrates;
                Bellabel2.Text = element.Protein;
                Jirlabel2.Text = element.Fats;
                Callabel2.Text = element.Callories;
                AllUgllabel.Text = (Convert.ToDecimal(Ugllabel1.Text) + Convert.ToDecimal(Ugllabel2.Text) + Convert.ToDecimal(Ugllabel3.Text) + Convert.ToDecimal(Ugllabel4.Text) + Convert.ToDecimal(Ugllabel5.Text) + Convert.ToDecimal(Ugllabel6.Text)).ToString();
                AllBellabel.Text = (Convert.ToDecimal(Bellabel1.Text) + Convert.ToDecimal(Bellabel2.Text) + Convert.ToDecimal(Bellabel3.Text) + Convert.ToDecimal(Bellabel4.Text) + Convert.ToDecimal(Bellabel5.Text) + Convert.ToDecimal(Bellabel6.Text)).ToString();
                AllJirlabel.Text = (Convert.ToDecimal(Jirlabel1.Text) + Convert.ToDecimal(Jirlabel2.Text) + Convert.ToDecimal(Jirlabel3.Text) + Convert.ToDecimal(Jirlabel4.Text) + Convert.ToDecimal(Jirlabel5.Text) + Convert.ToDecimal(Jirlabel6.Text)).ToString();
                AllCallabel.Text = (Convert.ToDecimal(Callabel1.Text) + Convert.ToDecimal(Callabel2.Text) + Convert.ToDecimal(Callabel3.Text) + Convert.ToDecimal(Callabel4.Text) + Convert.ToDecimal(Callabel5.Text) + Convert.ToDecimal(Callabel6.Text)).ToString();
            }
            catch (Exception)
            {
                MessageBox.Show("Ошибка в данных блюда! Проверьте правильность информации!");
            }
        }

        private void EatBox3_SelectedIndexChanged(object sender, EventArgs e)
        {
            EatBox3.Focus();
            try
            {
                Energoelements element = (Energoelements)EatBox3.SelectedItem;
                Ugllabel3.Text = element.Carbohydrates;
                Bellabel3.Text = element.Protein;
                Jirlabel3.Text = element.Fats;
                Callabel3.Text = element.Callories;
                AllUgllabel.Text = (Convert.ToDecimal(Ugllabel1.Text) + Convert.ToDecimal(Ugllabel2.Text) + Convert.ToDecimal(Ugllabel3.Text) + Convert.ToDecimal(Ugllabel4.Text) + Convert.ToDecimal(Ugllabel5.Text) + Convert.ToDecimal(Ugllabel6.Text)).ToString();
                AllBellabel.Text = (Convert.ToDecimal(Bellabel1.Text) + Convert.ToDecimal(Bellabel2.Text) + Convert.ToDecimal(Bellabel3.Text) + Convert.ToDecimal(Bellabel4.Text) + Convert.ToDecimal(Bellabel5.Text) + Convert.ToDecimal(Bellabel6.Text)).ToString();
                AllJirlabel.Text = (Convert.ToDecimal(Jirlabel1.Text) + Convert.ToDecimal(Jirlabel2.Text) + Convert.ToDecimal(Jirlabel3.Text) + Convert.ToDecimal(Jirlabel4.Text) + Convert.ToDecimal(Jirlabel5.Text) + Convert.ToDecimal(Jirlabel6.Text)).ToString();
                AllCallabel.Text = (Convert.ToDecimal(Callabel1.Text) + Convert.ToDecimal(Callabel2.Text) + Convert.ToDecimal(Callabel3.Text) + Convert.ToDecimal(Callabel4.Text) + Convert.ToDecimal(Callabel5.Text) + Convert.ToDecimal(Callabel6.Text)).ToString();
            }
            catch (Exception)
            {
                MessageBox.Show("Ошибка в данных блюда! Проверьте правильность информации!");
            }
        }

        private void EatBox4_SelectedIndexChanged(object sender, EventArgs e)
        {
            EatBox4.Focus();
            try
            {
                Energoelements element = (Energoelements)EatBox4.SelectedItem;
                Ugllabel4.Text = element.Carbohydrates;
                Bellabel4.Text = element.Protein;
                Jirlabel4.Text = element.Fats;
                Callabel4.Text = element.Callories;
                AllUgllabel.Text = (Convert.ToDecimal(Ugllabel1.Text) + Convert.ToDecimal(Ugllabel2.Text) + Convert.ToDecimal(Ugllabel3.Text) + Convert.ToDecimal(Ugllabel4.Text) + Convert.ToDecimal(Ugllabel5.Text) + Convert.ToDecimal(Ugllabel6.Text)).ToString();
                AllBellabel.Text = (Convert.ToDecimal(Bellabel1.Text) + Convert.ToDecimal(Bellabel2.Text) + Convert.ToDecimal(Bellabel3.Text) + Convert.ToDecimal(Bellabel4.Text) + Convert.ToDecimal(Bellabel5.Text) + Convert.ToDecimal(Bellabel6.Text)).ToString();
                AllJirlabel.Text = (Convert.ToDecimal(Jirlabel1.Text) + Convert.ToDecimal(Jirlabel2.Text) + Convert.ToDecimal(Jirlabel3.Text) + Convert.ToDecimal(Jirlabel4.Text) + Convert.ToDecimal(Jirlabel5.Text) + Convert.ToDecimal(Jirlabel6.Text)).ToString();
                AllCallabel.Text = (Convert.ToDecimal(Callabel1.Text) + Convert.ToDecimal(Callabel2.Text) + Convert.ToDecimal(Callabel3.Text) + Convert.ToDecimal(Callabel4.Text) + Convert.ToDecimal(Callabel5.Text) + Convert.ToDecimal(Callabel6.Text)).ToString();
            }
            catch (Exception)
            {
                MessageBox.Show("Ошибка в данных блюда! Проверьте правильность информации!");
            }
        }

        private void EatBox5_SelectedIndexChanged(object sender, EventArgs e)
        {
            EatBox5.Focus();
            try
            {
                Energoelements element = (Energoelements)EatBox5.SelectedItem;
                Ugllabel5.Text = element.Carbohydrates;
                Bellabel5.Text = element.Protein;
                Jirlabel5.Text = element.Fats;
                Callabel5.Text = element.Callories;
                AllUgllabel.Text = (Convert.ToDecimal(Ugllabel1.Text) + Convert.ToDecimal(Ugllabel2.Text) + Convert.ToDecimal(Ugllabel3.Text) + Convert.ToDecimal(Ugllabel4.Text) + Convert.ToDecimal(Ugllabel5.Text) + Convert.ToDecimal(Ugllabel6.Text)).ToString();
                AllBellabel.Text = (Convert.ToDecimal(Bellabel1.Text) + Convert.ToDecimal(Bellabel2.Text) + Convert.ToDecimal(Bellabel3.Text) + Convert.ToDecimal(Bellabel4.Text) + Convert.ToDecimal(Bellabel5.Text) + Convert.ToDecimal(Bellabel6.Text)).ToString();
                AllJirlabel.Text = (Convert.ToDecimal(Jirlabel1.Text) + Convert.ToDecimal(Jirlabel2.Text) + Convert.ToDecimal(Jirlabel3.Text) + Convert.ToDecimal(Jirlabel4.Text) + Convert.ToDecimal(Jirlabel5.Text) + Convert.ToDecimal(Jirlabel6.Text)).ToString();
                AllCallabel.Text = (Convert.ToDecimal(Callabel1.Text) + Convert.ToDecimal(Callabel2.Text) + Convert.ToDecimal(Callabel3.Text) + Convert.ToDecimal(Callabel4.Text) + Convert.ToDecimal(Callabel5.Text) + Convert.ToDecimal(Callabel6.Text)).ToString();
            }
            catch (Exception)
            {
                MessageBox.Show("Ошибка в данных блюда! Проверьте правильность информации!");
            }
        }

        private void EatBox6_SelectedIndexChanged(object sender, EventArgs e)
        {
            EatBox6.Focus();
            try
            {
                Energoelements element = (Energoelements)EatBox6.SelectedItem;
                Ugllabel6.Text = element.Carbohydrates;
                Bellabel6.Text = element.Protein;
                Jirlabel6.Text = element.Fats;
                Callabel6.Text = element.Callories;
                AllUgllabel.Text = (Convert.ToDecimal(Ugllabel1.Text) + Convert.ToDecimal(Ugllabel2.Text) + Convert.ToDecimal(Ugllabel3.Text) + Convert.ToDecimal(Ugllabel4.Text) + Convert.ToDecimal(Ugllabel5.Text) + Convert.ToDecimal(Ugllabel6.Text)).ToString();
                AllBellabel.Text = (Convert.ToDecimal(Bellabel1.Text) + Convert.ToDecimal(Bellabel2.Text) + Convert.ToDecimal(Bellabel3.Text) + Convert.ToDecimal(Bellabel4.Text) + Convert.ToDecimal(Bellabel5.Text) + Convert.ToDecimal(Bellabel6.Text)).ToString();
                AllJirlabel.Text = (Convert.ToDecimal(Jirlabel1.Text) + Convert.ToDecimal(Jirlabel2.Text) + Convert.ToDecimal(Jirlabel3.Text) + Convert.ToDecimal(Jirlabel4.Text) + Convert.ToDecimal(Jirlabel5.Text) + Convert.ToDecimal(Jirlabel6.Text)).ToString();
                AllCallabel.Text = (Convert.ToDecimal(Callabel1.Text) + Convert.ToDecimal(Callabel2.Text) + Convert.ToDecimal(Callabel3.Text) + Convert.ToDecimal(Callabel4.Text) + Convert.ToDecimal(Callabel5.Text) + Convert.ToDecimal(Callabel6.Text)).ToString();
            }
            catch (Exception)
            {
                MessageBox.Show("Ошибка в данных блюда! Проверьте правильность информации!");
            }
        }

        private void Eatbutton_Click(object sender, EventArgs e)
        {
            if (NamelistBox.SelectedItem == null)
            {
                MessageBox.Show("Выберете пользователя или добавьте нового!");
                return;
            }
            else
            {
                if (AllUgllabel.Text != "0" || AllBellabel.Text != "0" || AllJirlabel.Text != "0" || AllCallabel.Text != "0")
                {
                   User seluser = (User)NamelistBox.SelectedItem;


                        if (DateTime.Now.Date != seluser.Histories.Last().Date && seluser.Histories.Last().firsttime == false)
                        {
                        
                            History newhistory = new History { Date = DateTime.Now.Date, Countofeat = 1, UserId = seluser.Id, firsttime = false };
                            if (Convert.ToDecimal(AllUgllabel.Text) > Convert.ToDecimal(seluser.Edges.Carbohydrates))
                            {
                                MessageBox.Show("Вы превысили суточное потребление углеводов!");
                                return;
                            }
                            if (Convert.ToDecimal(AllBellabel.Text) > Convert.ToDecimal(seluser.Edges.Proteins))
                            {
                                MessageBox.Show("Вы превысили суточное протребление протеинов!");
                                return;
                            }
                            if (Convert.ToDecimal(AllJirlabel.Text) > Convert.ToDecimal(seluser.Edges.Fats))
                            {
                                MessageBox.Show("Вы превысили суточное потребление жиров!");
                                return;
                            }
                            if (Convert.ToDecimal(AllCallabel.Text) > Convert.ToDecimal(seluser.Edges.Calloriesedge))
                            {
                                MessageBox.Show("Вы превысили суточное потребление каллорий!");
                                return;
                            }
                            newhistory.CarboHydrates = AllUgllabel.Text;
                            newhistory.Proteins = AllBellabel.Text;
                            newhistory.Fats = AllJirlabel.Text;
                            newhistory.Callories = AllCallabel.Text;
                            if (EatBox1.SelectedItem != null)
                            {
                                newhistory.Foodname = EatBox1.Text;
                                if (EatBox2.SelectedItem != null || EatBox3.SelectedItem != null || EatBox4.SelectedItem != null || EatBox5.SelectedItem != null || EatBox6.SelectedItem != null)
                                    newhistory.Foodname += ",";
                            }
                            if (EatBox2.SelectedItem != null)
                            {
                                newhistory.Foodname += EatBox2.Text;
                                if (EatBox3.SelectedItem != null || EatBox4.SelectedItem != null || EatBox5.SelectedItem != null || EatBox6.SelectedItem != null)
                                    newhistory.Foodname += ",";

                            }
                            if (EatBox3.SelectedItem != null)
                            {
                                newhistory.Foodname += EatBox3.Text;
                                if (EatBox4.SelectedItem != null || EatBox5.SelectedItem != null || EatBox6.SelectedItem != null)
                                    newhistory.Foodname += ",";

                            }
                            if (EatBox4.SelectedItem != null)
                            {
                                newhistory.Foodname += EatBox4.Text;
                                if (EatBox5.SelectedItem != null || EatBox6.SelectedItem != null)
                                    newhistory.Foodname += ",";

                            }
                            if (EatBox5.SelectedItem != null)
                            {
                                newhistory.Foodname += EatBox5.Text;
                                if (EatBox6.SelectedItem != null)
                                {
                                    newhistory.Foodname += ",";
                                    newhistory.Foodname += EatBox6.Text;

                                }

                            }
                        using (var db = new Aplicatincontext())
                        {
                            var checkid = db.Histories.ToList();
                            newhistory.Id = checkid.Last().Id+1;

                            db.Histories.Add(newhistory);
                            db.SaveChanges();
                        }
                        seluser.Histories.Add(newhistory);
                        MessageBox.Show("Ням - Ням!");

                        }
                        else
                        {
                            History newhistory = new History { UserId = seluser.Id,Date = DateTime.Now.Date};
                            
                            if (!seluser.Histories.Last().firsttime)
                            {
                                newhistory.Countofeat = seluser.Histories.Last().Countofeat + 1;
                                if (newhistory.Countofeat > seluser.Edges.Numbereats)
                                {
                                    MessageBox.Show("Вы привысили количество приемов пищи!");
                                    return;
                                }

                            }

                            decimal edgecarbo = Convert.ToDecimal(seluser.Histories.Last().CarboHydrates) + Convert.ToDecimal(AllUgllabel.Text);
                            if (edgecarbo > Convert.ToDecimal(seluser.Edges.Carbohydrates))
                            {
                                MessageBox.Show("Вы превысили суточное потребление углеводов!");
                                return;
                            }
                            decimal edgeprot = Convert.ToDecimal(seluser.Histories.Last().Proteins) + Convert.ToDecimal(AllBellabel.Text);
                            if (edgeprot > Convert.ToDecimal(seluser.Edges.Proteins))
                            {
                                MessageBox.Show("Вы превысили суточное протребление протеинов!");
                                return;
                            }
                            decimal edgefat = Convert.ToDecimal(seluser.Histories.Last().Fats) + Convert.ToDecimal(AllJirlabel.Text);
                            if (edgefat > Convert.ToDecimal(seluser.Edges.Fats))
                            {
                                MessageBox.Show("Вы превысили суточное потребление жиров!");
                                return;
                            }
                            decimal edgecall = Convert.ToDecimal(seluser.Histories.Last().Callories) + Convert.ToDecimal(AllCallabel.Text);
                            if (edgecall > Convert.ToDecimal(seluser.Edges.Calloriesedge))
                            {
                                MessageBox.Show("Вы превысили суточное потребление каллорий!");
                                return;
                            }
                            newhistory.CarboHydrates = $"{edgecarbo}";
                            newhistory.Proteins = $"{edgeprot}";
                            newhistory.Fats = $"{edgefat}";
                            newhistory.Callories = $"{edgecall}";

                            if (EatBox1.SelectedItem != null)
                            {
                                newhistory.Foodname = EatBox1.Text;
                                if (EatBox2.SelectedItem != null || EatBox3.SelectedItem != null || EatBox4.SelectedItem != null || EatBox5.SelectedItem != null || EatBox6.SelectedItem != null)
                                    newhistory.Foodname += ",";
                            }
                            if (EatBox2.SelectedItem != null)
                            {
                                newhistory.Foodname += EatBox2.Text;
                                if (EatBox3.SelectedItem != null || EatBox4.SelectedItem != null || EatBox5.SelectedItem != null || EatBox6.SelectedItem != null)
                                    newhistory.Foodname += ",";

                            }
                            if (EatBox3.SelectedItem != null)
                            {
                                newhistory.Foodname += EatBox3.Text;
                                if (EatBox4.SelectedItem != null || EatBox5.SelectedItem != null || EatBox6.SelectedItem != null)
                                    newhistory.Foodname += ",";

                            }
                            if (EatBox4.SelectedItem != null)
                            {
                                newhistory.Foodname += EatBox4.Text;
                                if (EatBox5.SelectedItem != null || EatBox6.SelectedItem != null)
                                    newhistory.Foodname += ",";

                            }
                            if (EatBox5.SelectedItem != null)
                            {
                                newhistory.Foodname += EatBox5.Text;
                                if (EatBox6.SelectedItem != null)
                                {
                                    newhistory.Foodname += ",";
                                    newhistory.Foodname += EatBox6.Text;

                                }

                            }
                        using (var db = new Aplicatincontext())
                        {
                            if (!seluser.Histories.Last().firsttime)
                            {
                                var checkid = db.Histories.ToList();
                                newhistory.Id = checkid.Last().Id+1;
                            }
                            if (seluser.Histories.Last().firsttime)
                            {
                                newhistory.Countofeat = 1;
                                newhistory.firsttime = false;
                                newhistory.Id = seluser.Histories[0].Id;
                                //db.Histories.Remove(seluser.Histories.First());
                                seluser.Histories[0]=newhistory;
                                db.Histories.Update(newhistory);
                                db.SaveChanges();
                                MessageBox.Show("Ням - Ням!");
                                return;

                            }
                           
                            db.Histories.Add(newhistory);
                            db.SaveChanges();
                            

                            //NamelistBox.Items.Clear();
                            //NamelistBox.Items.AddRange(db.Users.Include(h=>h.Histories).Include(e=>e.Edges).ToArray());

                        }
                        seluser.Histories.Add(newhistory);
                        //NamelistBox.DisplayMember = "Name";
                        MessageBox.Show("Ням - Ням!");
                        }

                }
                else
                {
                    MessageBox.Show("Выберите хотя бы одно блюдо!");
                    return;
                }
                
                
            }
           
        }

            private void ClearEatpictureBox1_Click(object sender, EventArgs e)
        {
            AllUgllabel.Text = (Convert.ToDecimal(AllUgllabel.Text) - Convert.ToDecimal(Ugllabel1.Text)).ToString();
            AllBellabel.Text = (Convert.ToDecimal(AllBellabel.Text) - Convert.ToDecimal(Bellabel1.Text)).ToString();
            AllJirlabel.Text = (Convert.ToDecimal(AllJirlabel.Text) - Convert.ToDecimal(Jirlabel1.Text)).ToString();
            AllCallabel.Text = (Convert.ToDecimal(AllCallabel.Text) - Convert.ToDecimal(Callabel1.Text)).ToString();
            Ugllabel1.Text = "0";
            Bellabel1.Text = "0";
            Jirlabel1.Text = "0";
            Callabel1.Text = "0";
            EatBox1.Focus();
            EatBox1.SelectedText = "";
        }

        private void ClearEatpictureBox2_Click(object sender, EventArgs e)
        {
            AllUgllabel.Text = (Convert.ToDecimal(AllUgllabel.Text) - Convert.ToDecimal(Ugllabel2.Text)).ToString();
            AllBellabel.Text = (Convert.ToDecimal(AllBellabel.Text) - Convert.ToDecimal(Bellabel2.Text)).ToString();
            AllJirlabel.Text = (Convert.ToDecimal(AllJirlabel.Text) - Convert.ToDecimal(Jirlabel2.Text)).ToString();
            AllCallabel.Text = (Convert.ToDecimal(AllCallabel.Text) - Convert.ToDecimal(Callabel2.Text)).ToString();
            Ugllabel2.Text = "0";
            Bellabel2.Text = "0";
            Jirlabel2.Text = "0";
            Callabel2.Text = "0";
            EatBox2.Focus();
            EatBox2.SelectedText = "";
        }

        private void ClearEatpictureBox3_Click(object sender, EventArgs e)
        {
            AllUgllabel.Text = (Convert.ToDecimal(AllUgllabel.Text) - Convert.ToDecimal(Ugllabel3.Text)).ToString();
            AllBellabel.Text = (Convert.ToDecimal(AllBellabel.Text) - Convert.ToDecimal(Bellabel3.Text)).ToString();
            AllJirlabel.Text = (Convert.ToDecimal(AllJirlabel.Text) - Convert.ToDecimal(Jirlabel3.Text)).ToString();
            AllCallabel.Text = (Convert.ToDecimal(AllCallabel.Text) - Convert.ToDecimal(Callabel3.Text)).ToString();
            Ugllabel3.Text = "0";
            Bellabel3.Text = "0";
            Jirlabel3.Text = "0";
            Callabel3.Text = "0";
            EatBox3.Focus();
            EatBox3.SelectedText = "";
        }

        private void ClearEatpictureBox4_Click(object sender, EventArgs e)
        {
            AllUgllabel.Text = (Convert.ToDecimal(AllUgllabel.Text) - Convert.ToDecimal(Ugllabel4.Text)).ToString();
            AllBellabel.Text = (Convert.ToDecimal(AllBellabel.Text) - Convert.ToDecimal(Bellabel4.Text)).ToString();
            AllJirlabel.Text = (Convert.ToDecimal(AllJirlabel.Text) - Convert.ToDecimal(Jirlabel4.Text)).ToString();
            AllCallabel.Text = (Convert.ToDecimal(AllCallabel.Text) - Convert.ToDecimal(Callabel4.Text)).ToString();
            Ugllabel4.Text = "0";
            Bellabel4.Text = "0";
            Jirlabel4.Text = "0";
            Callabel4.Text = "0";
            EatBox4.Focus();
            EatBox4.SelectedText = "";
        }

        private void ClearEatpictureBox5_Click(object sender, EventArgs e)
        {
            AllUgllabel.Text = (Convert.ToDecimal(AllUgllabel.Text) - (Convert.ToDecimal(Ugllabel5.Text))).ToString();
            AllBellabel.Text = (Convert.ToDecimal(AllBellabel.Text) - (Convert.ToDecimal(Bellabel5.Text))).ToString();
            AllJirlabel.Text = (Convert.ToDecimal(AllJirlabel.Text) - (Convert.ToDecimal(Jirlabel5.Text))).ToString();
            AllCallabel.Text = (Convert.ToDecimal(AllCallabel.Text) - (Convert.ToDecimal(Callabel5.Text))).ToString();
            Ugllabel5.Text = "0";
            Bellabel5.Text = "0";
            Jirlabel5.Text = "0";
            Callabel5.Text = "0";
            EatBox5.Focus();
            EatBox5.SelectedText = "";
        }

        private void ClearEatpictureBox6_Click(object sender, EventArgs e)
        {
            AllUgllabel.Text = (Convert.ToDecimal(AllUgllabel.Text) - (Convert.ToDecimal(Ugllabel6.Text))).ToString();
            AllBellabel.Text = (Convert.ToDecimal(AllBellabel.Text) - (Convert.ToDecimal(Bellabel6.Text))).ToString();
            AllJirlabel.Text = (Convert.ToDecimal(AllJirlabel.Text) - (Convert.ToDecimal(Jirlabel6.Text))).ToString();
            AllCallabel.Text = (Convert.ToDecimal(AllCallabel.Text) - (Convert.ToDecimal(Callabel6.Text))).ToString();
            Ugllabel6.Text = "0";
            Bellabel6.Text = "0";
            Jirlabel6.Text = "0";
            Callabel6.Text = "0";
            EatBox6.Focus();
            EatBox6.SelectedText = "";
        }

        private void AddEatpictureBox1_Click(object sender, EventArgs e)
        {
            EatBox1.Focus();
            Energoelements setel = (Energoelements)EatBox1.SelectedItem;
            if (EatBox1.SelectedItem == null)
                return;
                    Ugllabel1.Text = (Convert.ToDecimal(Ugllabel1.Text) + Convert.ToDecimal(setel.Carbohydrates)).ToString();
                    Bellabel1.Text = (Convert.ToDecimal(Bellabel1.Text) + Convert.ToDecimal(setel.Protein)).ToString();
                    Jirlabel1.Text = (Convert.ToDecimal(Jirlabel1.Text) + Convert.ToDecimal(setel.Fats)).ToString();
                    Callabel1.Text = (Convert.ToDecimal(Callabel1.Text) + Convert.ToDecimal(setel.Callories)).ToString();
                    AllUgllabel.Text = (Convert.ToDecimal(AllUgllabel.Text) + Convert.ToDecimal(setel.Carbohydrates)).ToString();
                    AllBellabel.Text = (Convert.ToDecimal(AllBellabel.Text) + Convert.ToDecimal(setel.Protein)).ToString();
                    AllJirlabel.Text = (Convert.ToDecimal(AllJirlabel.Text) + Convert.ToDecimal(setel.Fats)).ToString();
                    AllCallabel.Text = (Convert.ToDecimal(AllCallabel.Text) + Convert.ToDecimal(setel.Callories)).ToString();
        }

        private void AddEatpictureBox2_Click(object sender, EventArgs e)
        {
            EatBox2.Focus();
            Energoelements setel = (Energoelements)EatBox2.SelectedItem;

            if (EatBox2.SelectedItem == null)
                return;
            Ugllabel2.Text = (Convert.ToDecimal(Ugllabel2.Text) + Convert.ToDecimal(setel.Carbohydrates)).ToString();
            Bellabel2.Text = (Convert.ToDecimal(Bellabel2.Text) + Convert.ToDecimal(setel.Protein)).ToString();
            Jirlabel2.Text = (Convert.ToDecimal(Jirlabel2.Text) + Convert.ToDecimal(setel.Fats)).ToString();
            Callabel2.Text = (Convert.ToDecimal(Callabel2.Text) + Convert.ToDecimal(setel.Callories)).ToString();
            AllUgllabel.Text = (Convert.ToDecimal(AllUgllabel.Text) + Convert.ToDecimal(setel.Carbohydrates)).ToString();
            AllBellabel.Text = (Convert.ToDecimal(AllBellabel.Text) + Convert.ToDecimal(setel.Protein)).ToString();
            AllJirlabel.Text = (Convert.ToDecimal(AllJirlabel.Text) + Convert.ToDecimal(setel.Fats)).ToString();
            AllCallabel.Text = (Convert.ToDecimal(AllCallabel.Text) + Convert.ToDecimal(setel.Callories)).ToString();

        }

        private void AddEatpictureBox3_Click(object sender, EventArgs e)
        {
            EatBox3.Focus();
            Energoelements setel = (Energoelements)EatBox3.SelectedItem;

            if (EatBox3.SelectedItem == null)
                return;
            Ugllabel3.Text = (Convert.ToDecimal(Ugllabel3.Text) + Convert.ToDecimal(setel.Carbohydrates)).ToString();
            Bellabel3.Text = (Convert.ToDecimal(Bellabel3.Text) + Convert.ToDecimal(setel.Protein)).ToString();
            Jirlabel3.Text = (Convert.ToDecimal(Jirlabel3.Text) + Convert.ToDecimal(setel.Fats)).ToString();
            Callabel3.Text = (Convert.ToDecimal(Callabel3.Text) + Convert.ToDecimal(setel.Callories)).ToString();
            AllUgllabel.Text = (Convert.ToDecimal(AllUgllabel.Text) + Convert.ToDecimal(setel.Carbohydrates)).ToString();
            AllBellabel.Text = (Convert.ToDecimal(AllBellabel.Text) + Convert.ToDecimal(setel.Protein)).ToString();
            AllJirlabel.Text = (Convert.ToDecimal(AllJirlabel.Text) + Convert.ToDecimal(setel.Fats)).ToString();
            AllCallabel.Text = (Convert.ToDecimal(AllCallabel.Text) + Convert.ToDecimal(setel.Callories)).ToString();
        }

        private void AddEatpictureBox4_Click(object sender, EventArgs e)
        {
            EatBox4.Focus();
            Energoelements setel = (Energoelements)EatBox4.SelectedItem;

            if (EatBox4.SelectedItem == null)
                return;
            Ugllabel4.Text = (Convert.ToDecimal(Ugllabel4.Text) + Convert.ToDecimal(setel.Carbohydrates)).ToString();
            Bellabel4.Text = (Convert.ToDecimal(Bellabel4.Text) + Convert.ToDecimal(setel.Protein)).ToString();
            Jirlabel4.Text = (Convert.ToDecimal(Jirlabel4.Text) + Convert.ToDecimal(setel.Fats)).ToString();
            Callabel4.Text = (Convert.ToDecimal(Callabel4.Text) + Convert.ToDecimal(setel.Callories)).ToString();
            AllUgllabel.Text = (Convert.ToDecimal(AllUgllabel.Text) + Convert.ToDecimal(setel.Carbohydrates)).ToString();
            AllBellabel.Text = (Convert.ToDecimal(AllBellabel.Text) + Convert.ToDecimal(setel.Protein)).ToString();
            AllJirlabel.Text = (Convert.ToDecimal(AllJirlabel.Text) + Convert.ToDecimal(setel.Fats)).ToString();
            AllCallabel.Text = (Convert.ToDecimal(AllCallabel.Text) + Convert.ToDecimal(setel.Callories)).ToString();

        }

        private void AddEatpictureBox5_Click(object sender, EventArgs e)
        {
            EatBox5.Focus();
            Energoelements setel = (Energoelements)EatBox5.SelectedItem;

            if (EatBox5.SelectedItem == null)
                return;
            Ugllabel5.Text = (Convert.ToDecimal(Ugllabel5.Text) + Convert.ToDecimal(setel.Carbohydrates)).ToString();
            Bellabel5.Text = (Convert.ToDecimal(Bellabel5.Text) + Convert.ToDecimal(setel.Protein)).ToString();
            Jirlabel5.Text = (Convert.ToDecimal(Jirlabel5.Text) + Convert.ToDecimal(setel.Fats)).ToString();
            Callabel5.Text = (Convert.ToDecimal(Callabel5.Text) + Convert.ToDecimal(setel.Callories)).ToString();
            AllUgllabel.Text = (Convert.ToDecimal(AllUgllabel.Text) + Convert.ToDecimal(setel.Carbohydrates)).ToString();
            AllBellabel.Text = (Convert.ToDecimal(AllBellabel.Text) + Convert.ToDecimal(setel.Protein)).ToString();
            AllJirlabel.Text = (Convert.ToDecimal(AllJirlabel.Text) + Convert.ToDecimal(setel.Fats)).ToString();
            AllCallabel.Text = (Convert.ToDecimal(AllCallabel.Text) + Convert.ToDecimal(setel.Callories)).ToString();
        }

        private void AddEatpictureBox6_Click(object sender, EventArgs e)
        {
            EatBox6.Focus();
            Energoelements setel = (Energoelements)EatBox6.SelectedItem;

            if (EatBox6.SelectedItem == null)
                return;
            Ugllabel6.Text = (Convert.ToDecimal(Ugllabel6.Text) + Convert.ToDecimal(setel.Carbohydrates)).ToString();
            Bellabel6.Text = (Convert.ToDecimal(Bellabel6.Text) + Convert.ToDecimal(setel.Protein)).ToString();
            Jirlabel6.Text = (Convert.ToDecimal(Jirlabel6.Text) + Convert.ToDecimal(setel.Fats)).ToString();
            Callabel6.Text = (Convert.ToDecimal(Callabel6.Text) + Convert.ToDecimal(setel.Callories)).ToString();
            AllUgllabel.Text = (Convert.ToDecimal(AllUgllabel.Text) + Convert.ToDecimal(setel.Carbohydrates)).ToString();
            AllBellabel.Text = (Convert.ToDecimal(AllBellabel.Text) + Convert.ToDecimal(setel.Protein)).ToString();
            AllJirlabel.Text = (Convert.ToDecimal(AllJirlabel.Text) + Convert.ToDecimal(setel.Fats)).ToString();
            AllCallabel.Text = (Convert.ToDecimal(AllCallabel.Text) + Convert.ToDecimal(setel.Callories)).ToString();
        }


        private void DeleteFoodBut_Click(object sender, EventArgs e)
        {
            Size = new Size(276, 267);
            Panel deletefoodpanel = new Panel
            {
                Size = new Size(262, 230),
                Location = new Point(0)
            };
            Controls.Add(deletefoodpanel);
            deletefoodpanel.BringToFront();
            Button deletefoodbutton = new Button
            {
                Size = new Size(131, 30),
                Location = new Point(-1, 198),
                Text = "Удалить"
            };
            deletefoodpanel.Controls.Add(deletefoodbutton);
            Button Cancelfoodbutton = new Button
            {
                Size = new Size(131, 30),
                Location = new Point(130, 198),
                Text = "Отмена"
            };
            deletefoodpanel.Controls.Add(Cancelfoodbutton);

            ListBox deletefoodlistbox = new ListBox
            {
                Size = new Size(276, 200),
                Location = new Point(0)
            };
            deletefoodpanel.Controls.Add(deletefoodlistbox);
            deletefoodlistbox.Items.AddRange(_elements.ToArray());
            deletefoodlistbox.DisplayMember = "Name";
            deletefoodbutton.Click += DeleteClick;
            void DeleteClick(object but,EventArgs click)
            {
                if (deletefoodlistbox.SelectedItem != null)
                {
                    Energoelements setel = (Energoelements)deletefoodlistbox.SelectedItem;
                    using (var db = new Aplicatincontext())
                    {
                        db.Elements.Remove(setel);
                        db.SaveChanges();
                    }
                    if (EatBox1.Items.Contains(setel)&&EatBox2.Items.Contains(setel)&&EatBox3.Items.Contains(setel)&&EatBox4.Items.Contains(setel)&&EatBox5.Items.Contains(setel)&&EatBox6.Items.Contains(setel))
                    {
                        if (EatBox1.SelectedItem == setel)
                        {
                            AllUgllabel.Text = (Convert.ToDecimal(AllUgllabel.Text) - Convert.ToDecimal(Ugllabel1.Text)).ToString();
                            AllBellabel.Text = (Convert.ToDecimal(AllBellabel.Text) - Convert.ToDecimal(Bellabel1.Text)).ToString();
                            AllJirlabel.Text = (Convert.ToDecimal(AllJirlabel.Text) - Convert.ToDecimal(Jirlabel1.Text)).ToString();
                            AllCallabel.Text = (Convert.ToDecimal(AllCallabel.Text) - Convert.ToDecimal(Callabel1.Text)).ToString();
                            Ugllabel1.Text = "0";
                            Bellabel1.Text = "0";
                            Jirlabel1.Text = "0";
                            Callabel1.Text = "0";
                        }
                        EatBox1.Items.Remove(setel);
                        if(EatBox2.SelectedItem==setel)
                        {
                            AllUgllabel.Text = (Convert.ToDecimal(AllUgllabel.Text) - Convert.ToDecimal(Ugllabel2.Text)).ToString();
                            AllBellabel.Text = (Convert.ToDecimal(AllBellabel.Text) - Convert.ToDecimal(Bellabel2.Text)).ToString();
                            AllJirlabel.Text = (Convert.ToDecimal(AllJirlabel.Text) - Convert.ToDecimal(Jirlabel2.Text)).ToString();
                            AllCallabel.Text = (Convert.ToDecimal(AllCallabel.Text) - Convert.ToDecimal(Callabel2.Text)).ToString();
                            Ugllabel2.Text = "0";
                            Bellabel2.Text = "0";
                            Jirlabel2.Text = "0";
                            Callabel2.Text = "0";
                        }
                        EatBox2.Items.Remove(setel);
                        if(EatBox3.SelectedItem==setel)
                        {
                            AllUgllabel.Text = (Convert.ToDecimal(AllUgllabel.Text) - Convert.ToDecimal(Ugllabel3.Text)).ToString();
                            AllBellabel.Text = (Convert.ToDecimal(AllBellabel.Text) - Convert.ToDecimal(Bellabel3.Text)).ToString();
                            AllJirlabel.Text = (Convert.ToDecimal(AllJirlabel.Text) - Convert.ToDecimal(Jirlabel3.Text)).ToString();
                            AllCallabel.Text = (Convert.ToDecimal(AllCallabel.Text) - Convert.ToDecimal(Callabel3.Text)).ToString();
                            Ugllabel3.Text = "0";
                            Bellabel3.Text = "0";
                            Jirlabel3.Text = "0";
                            Callabel3.Text = "0";
                        }
                        EatBox3.Items.Remove(setel);
                        if(EatBox4.SelectedItem==setel)
                        {
                            AllUgllabel.Text = (Convert.ToDecimal(AllUgllabel.Text) - Convert.ToDecimal(Ugllabel4.Text)).ToString();
                            AllBellabel.Text = (Convert.ToDecimal(AllBellabel.Text) - Convert.ToDecimal(Bellabel4.Text)).ToString();
                            AllJirlabel.Text = (Convert.ToDecimal(AllJirlabel.Text) - Convert.ToDecimal(Jirlabel4.Text)).ToString();
                            AllCallabel.Text = (Convert.ToDecimal(AllCallabel.Text) - Convert.ToDecimal(Callabel4.Text)).ToString();
                            Ugllabel4.Text = "0";
                            Bellabel4.Text = "0";
                            Jirlabel4.Text = "0";
                            Callabel4.Text = "0";
                        }
                        EatBox4.Items.Remove(setel);
                        if(EatBox5.SelectedItem == setel)
                        {
                            AllUgllabel.Text = (Convert.ToDecimal(AllUgllabel.Text) - (Convert.ToDecimal(Ugllabel5.Text))).ToString();
                            AllBellabel.Text = (Convert.ToDecimal(AllBellabel.Text) - (Convert.ToDecimal(Bellabel5.Text))).ToString();
                            AllJirlabel.Text = (Convert.ToDecimal(AllJirlabel.Text) - (Convert.ToDecimal(Jirlabel5.Text))).ToString();
                            AllCallabel.Text = (Convert.ToDecimal(AllCallabel.Text) - (Convert.ToDecimal(Callabel5.Text))).ToString();
                            Ugllabel5.Text = "0";
                            Bellabel5.Text = "0";
                            Jirlabel5.Text = "0";
                            Callabel5.Text = "0";
                        }
                        EatBox5.Items.Remove(setel);
                        if(EatBox6.SelectedItem == setel)
                        {
                            AllUgllabel.Text = (Convert.ToDecimal(AllUgllabel.Text) - (Convert.ToDecimal(Ugllabel6.Text))).ToString();
                            AllBellabel.Text = (Convert.ToDecimal(AllBellabel.Text) - (Convert.ToDecimal(Bellabel6.Text))).ToString();
                            AllJirlabel.Text = (Convert.ToDecimal(AllJirlabel.Text) - (Convert.ToDecimal(Jirlabel6.Text))).ToString();
                            AllCallabel.Text = (Convert.ToDecimal(AllCallabel.Text) - (Convert.ToDecimal(Callabel6.Text))).ToString();
                            Ugllabel6.Text = "0";
                            Bellabel6.Text = "0";
                            Jirlabel6.Text = "0";
                            Callabel6.Text = "0";
                        }
                        EatBox6.Items.Remove(setel);
                    }
                    deletefoodlistbox.Items.Remove(setel);
                }
               
            }
            Cancelfoodbutton.Click += CancelClick;
            void CancelClick(object but,EventArgs click)
            {
                deletefoodpanel.Dispose();
                Size = new Size(890, 430);
            }
        }


        //Функционал кнопки "Пользователь"
        private void UserBut_Click(object sender, EventArgs e)
        {
            Size = new Size(890, 520);
            UserBut.Hide();
            FoodBut.Hide();
            ClearFoodBut.Enabled = false;
            Eatbutton.Enabled = false;
            Historybutton.Enabled = false;
            

            Panel UserFoodPan = new Panel
            {
                Size = new Size(490,40),
                Location = new Point(288,10)

            };
            Controls.Add(UserFoodPan);

            Button Addbutton = new Button
            {
                Size = new Size(115, 40),
                Location = new Point(0),
                Text = "Добавить",
                FlatStyle = FlatStyle.Flat,
                BackColor = SystemColors.GradientActiveCaption,
                Cursor = Cursors.Hand,
                Font = new Font("Segoe Script", 8F, FontStyle.Bold, GraphicsUnit.Point),
                Margin = new Padding(0),



            };
            UserFoodPan.Controls.Add(Addbutton);
            Addbutton.FlatAppearance.BorderColor = Color.Blue;
            Addbutton.FlatAppearance.MouseDownBackColor = Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(64)))), ((int)(((byte)(0)))));
            Addbutton.FlatAppearance.MouseOverBackColor = Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(192)))), ((int)(((byte)(0)))));



            Button UpdateBut = new Button
            {
                Size = new Size(115, 40),
                Location = new Point(120),
                Text = "Редактировать",
                FlatStyle = FlatStyle.Flat,
                BackColor = SystemColors.GradientActiveCaption,
                Cursor = Cursors.Hand,
                Font = new Font("Segoe Script", 8F, FontStyle.Bold, GraphicsUnit.Point),
                Margin = new Padding(0),
            };
            UserFoodPan.Controls.Add(UpdateBut);
            UpdateBut.FlatAppearance.BorderColor = Color.Blue;
            UpdateBut.FlatAppearance.MouseDownBackColor = Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(64)))), ((int)(((byte)(0)))));
            UpdateBut.FlatAppearance.MouseOverBackColor = Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(192)))), ((int)(((byte)(0)))));



            Button DeleteUserBut = new Button
            {
                Size = new Size(115, 40),
                Location = new Point(240),
                Text = "Удалить",
                FlatStyle = FlatStyle.Flat,
                BackColor = SystemColors.GradientActiveCaption,
                Cursor = Cursors.Hand,
                Font = new Font("Segoe Script", 8F, FontStyle.Bold, GraphicsUnit.Point),
                Margin = new Padding(0),

            };
            UserFoodPan.Controls.Add(DeleteUserBut);
            DeleteUserBut.FlatAppearance.BorderColor = Color.Blue;
            DeleteUserBut.FlatAppearance.MouseDownBackColor = Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(64)))), ((int)(((byte)(0)))));
            DeleteUserBut.FlatAppearance.MouseOverBackColor = Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(192)))), ((int)(((byte)(0)))));


            Button CancelBut = new Button
            {
                Size = new Size(115, 40),
                Location = new Point(360),
                Text = "Отмена",
                FlatStyle = FlatStyle.Flat,
                BackColor = SystemColors.GradientActiveCaption,
                Cursor = Cursors.Hand,
                Font = new Font("Segoe Script", 8F, FontStyle.Bold, GraphicsUnit.Point),
                Margin = new Padding(0),


            };
            UserFoodPan.Controls.Add(CancelBut);
            CancelBut.FlatAppearance.BorderColor = Color.Blue;
            CancelBut.FlatAppearance.MouseDownBackColor = Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(64)))), ((int)(((byte)(0)))));
            CancelBut.FlatAppearance.MouseOverBackColor = Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(192)))), ((int)(((byte)(0)))));


            //Функционал кнопки "Отмена"

            CancelBut.Click += CancelButClick;
            void CancelButClick(object but, EventArgs click)
            {
                UserFoodPan.Dispose();
                ClearFoodBut.Enabled = true;
                Historybutton.Enabled = true;
                Eatbutton.Enabled = true;
                NamelistBox.Enabled = true;
                Size = new Size(890, 430);
                UserBut.Show();
                FoodBut.Show();
                if(Controls.ContainsKey("adduserpanel"))
                {
                    Controls.RemoveByKey("adduserpanel");
                }
                if(Controls.ContainsKey("upduserpanel"))
                {
                    Controls.RemoveByKey("upduserpanel");
                }

            }

            //Функционал Кнопки "Добавить"

            Addbutton.Click += AddClick;
            void AddClick(object but, EventArgs click)
            {
                if (Controls.ContainsKey("upduserpanel"))
                {
                    Controls.RemoveByKey("upduserpanel");

                }
                Addbutton.Enabled = false;
                UpdateBut.Enabled = true;
                DeleteUserBut.Enabled = true;
                NamelistBox.Enabled = false;
                
               

                Panel adduserpanel = new Panel
                {
                    Size = new Size(635, 95),
                    BackColor = Color.Aquamarine,
                    Location = new Point(11, 380),
                    Name = "adduserpanel"
                    

                };
                Controls.Add(adduserpanel);


                Label addname = new Label
                {

                    Location = new Point(8, 10),
                    Text = "Имя",
                    AutoSize = true,


                };
                adduserpanel.Controls.Add(addname);
                addname.BringToFront();

                Label addcarbohyd = new Label
                {
                    Location = new Point(88, 10),
                    Text = "Макс. углеводов",
                    AutoSize = true
                };
                adduserpanel.Controls.Add(addcarbohyd);
                addcarbohyd.BringToFront();

                Label addproteins = new Label
                {
                    Location = new Point(203, 10),
                    Text = "Макс. протеинов",
                    AutoSize = true

                };
                adduserpanel.Controls.Add(addproteins);
                addproteins.BringToFront();

                Label addfats = new Label
                {
                    Location = new Point(312, 10),
                    Text = "Макс. жиров",
                    AutoSize = true

                };
                adduserpanel.Controls.Add(addfats);
                addfats.BringToFront();

                Label addcallories = new Label
                {
                    Location = new Point(407, 10),
                    Text = "Макс. каллорий",
                    AutoSize = true
                };
                adduserpanel.Controls.Add(addcallories);
                addcallories.BringToFront();

                Label addeat = new Label
                {
                    Location = new Point(520, 10),
                    Text = "Количество трапез",
                    AutoSize = true
                };
                adduserpanel.Controls.Add(addeat);
                addeat.BringToFront();

                TextBox namebox = new TextBox
                {
                    Location = new Point(10, 30),
                    Font = new Font(FontFamily.GenericSansSerif, 8),
                    Size = new Size(60, 20)
                };
                adduserpanel.Controls.Add(namebox);
                namebox.BringToFront();

                TextBox carbohydbox = new TextBox
                {
                    Location = new Point(117, 30),
                    Font = new Font(FontFamily.GenericSansSerif, 8),
                    Size = new Size(40, 20)
                };
                adduserpanel.Controls.Add(carbohydbox);
                carbohydbox.BringToFront();

                TextBox proteinbox = new TextBox
                {
                    Location = new Point(230, 30),
                    Font = new Font(FontFamily.GenericSansSerif, 8),
                    Size = new Size(40, 20)
                };
                adduserpanel.Controls.Add(proteinbox);
                proteinbox.BringToFront();

                TextBox fatsbox = new TextBox
                {
                    Location = new Point(337, 30),
                    Font = new Font(FontFamily.GenericSansSerif, 8),
                    Size = new Size(40, 20)
                };
                adduserpanel.Controls.Add(fatsbox);
                fatsbox.BringToFront();

                TextBox calloriesbox = new TextBox
                {
                    Location = new Point(437, 30),
                    Font = new Font(FontFamily.GenericSansSerif, 8),
                    Size = new Size(40, 20)
                };
                adduserpanel.Controls.Add(calloriesbox);
                calloriesbox.BringToFront();

                TextBox numbereat = new TextBox
                {
                    Location = new Point(555, 30),
                    Font = new Font(FontFamily.GenericSansSerif, 8),
                    Size = new Size(40, 20)
                };
                adduserpanel.Controls.Add(numbereat);
                numbereat.BringToFront();

                Button adduserbut = new Button
                {
                    Location = new Point(229, 55),
                    Text = "Добавить"
                };
                adduserpanel.Controls.Add(adduserbut);
                adduserbut.BringToFront();

                Button cancelbut = new Button
                {
                    Location = new Point(336, 55),
                    Text = "Отмена"
                };
                adduserpanel.Controls.Add(cancelbut);
                cancelbut.BringToFront();

                //Функционал кнопки добавления

                adduserbut.Click += AddUserClick;
                void AddUserClick(object but, EventArgs click)
                {
                    if (namebox.Text != "" && carbohydbox.Text != "" && proteinbox.Text != "" && fatsbox.Text != "" && calloriesbox.Text != "" && numbereat.Text != "")
                    {
                        try
                        {
                            User newuser = new User { Name = namebox.Text };
                            Edgeelements edgeelements = new Edgeelements { Calloriesedge = calloriesbox.Text, Carbohydrates = (carbohydbox.Text), Fats = (fatsbox.Text), Proteins = (proteinbox.Text), Numbereats = Convert.ToInt32(numbereat.Text), user = newuser };
                            History newhistory = new History { UserId = newuser.Id, user = newuser, CarboHydrates = "0", Proteins = "0", Fats = "0", Callories = "0", Countofeat = 0, firsttime = true };
                            MessageBox.Show("Пользователь успешно добавлен");

                            NamelistBox.Items.Add(newuser);

                            using (var db = new Aplicatincontext())
                            {
                                db.Users.Add(newuser);
                                db.Edges.Add(edgeelements);
                                db.Histories.Add(newhistory);
                                db.SaveChanges();
                            }


                        }
                        catch (Exception)
                        {
                            MessageBox.Show("Неправильное значение");
                        }

                    }
                    else
                    {
                        MessageBox.Show("Заполните все поля!");

                    }
                    adduserpanel.Dispose();
                    Addbutton.Enabled = true;
                    DeleteUserBut.Enabled = true;
                    UpdateBut.Enabled = true;
                    NamelistBox.Enabled = true;
                   
                }

                //Функционал кнопки отмены

                cancelbut.Click += CancelAddUserClick;
                void CancelAddUserClick(object but,EventArgs click)
                {
                    adduserpanel.Dispose();
                    Addbutton.Enabled = true;
                    DeleteUserBut.Enabled = true;
                    UpdateBut.Enabled = true;
                    NamelistBox.Enabled = true;
      
                }


            }

            //Функционал кнопки "Редактировать"

            UpdateBut.Click += UpdateButClick;
            void UpdateButClick(object but,EventArgs click)
            {
                if(NamelistBox.SelectedItem==null)
                {
                    MessageBox.Show("Выберете пользователя!");
                    return;
                }
                if(Controls.ContainsKey("adduserpanel"))
                {
                    Controls.RemoveByKey("adduserpanel");
                    
                }
                
                Addbutton.Enabled = true;
                UpdateBut.Enabled = false;
                DeleteUserBut.Enabled = true;
                NamelistBox.Enabled = false;

                Panel upduserpanel = new Panel
                {
                    Size = new Size(635, 95),
                    BackColor = Color.CornflowerBlue,
                    Location = new Point(11, 380),
                    Name = "upduserpanel"

                };
                Controls.Add(upduserpanel);


                Label updname = new Label
                {

                    Location = new Point(8, 10),
                    Text = "Имя",
                    AutoSize = true,

                };
                upduserpanel.Controls.Add(updname);
                updname.BringToFront();

                Label updcarbohyd = new Label
                {
                    Location = new Point(88, 10),
                    Text = "Макс. углеводов",
                    AutoSize = true
                };
                upduserpanel.Controls.Add(updcarbohyd);
                updcarbohyd.BringToFront();

                Label updproteins = new Label
                {
                    Location = new Point(203, 10),
                    Text = "Макс. протеинов",
                    AutoSize = true

                };
                upduserpanel.Controls.Add(updproteins);
                updproteins.BringToFront();

                Label updfats = new Label
                {
                    Location = new Point(312, 10),
                    Text = "Макс. жиров",
                    AutoSize = true

                };
                upduserpanel.Controls.Add(updfats);
                updfats.BringToFront();

                Label updcallories = new Label
                {
                    Location = new Point(407, 10),
                    Text = "Макс. каллорий",
                    AutoSize = true
                };
                upduserpanel.Controls.Add(updcallories);
                updcallories.BringToFront();

                Label updeat = new Label
                {
                    Location = new Point(520, 10),
                    Text = "Количество трапез",
                    AutoSize = true
                };
                upduserpanel.Controls.Add(updeat);
                updeat.BringToFront();

                TextBox namebox = new TextBox
                {
                    Location = new Point(10, 30),
                    Font = new Font(FontFamily.GenericSansSerif, 8),
                    Size = new Size(60, 20)
                };
                upduserpanel.Controls.Add(namebox);
                namebox.BringToFront();

                TextBox carbohydbox = new TextBox
                {
                    Location = new Point(117, 30),
                    Font = new Font(FontFamily.GenericSansSerif, 8),
                    Size = new Size(40, 20)
                };
                upduserpanel.Controls.Add(carbohydbox);
                carbohydbox.BringToFront();

                TextBox proteinbox = new TextBox
                {
                    Location = new Point(230, 30),
                    Font = new Font(FontFamily.GenericSansSerif, 8),
                    Size = new Size(40, 20)
                };
                upduserpanel.Controls.Add(proteinbox);
                proteinbox.BringToFront();

                TextBox fatsbox = new TextBox
                {
                    Location = new Point(337, 30),
                    Font = new Font(FontFamily.GenericSansSerif, 8),
                    Size = new Size(40, 20)
                };
                upduserpanel.Controls.Add(fatsbox);
                fatsbox.BringToFront();

                TextBox calloriesbox = new TextBox
                {
                    Location = new Point(437, 30),
                    Font = new Font(FontFamily.GenericSansSerif, 8),
                    Size = new Size(40, 20)
                };
                upduserpanel.Controls.Add(calloriesbox);
                calloriesbox.BringToFront();

                TextBox numbereat = new TextBox
                {
                    Location = new Point(555, 30),
                    Font = new Font(FontFamily.GenericSansSerif, 8),
                    Size = new Size(40, 20)
                };
                upduserpanel.Controls.Add(numbereat);
                numbereat.BringToFront();

                Button upduserbut = new Button
                {
                    Location = new Point(229, 55),
                    Text = "Обновить"
                };
                upduserpanel.Controls.Add(upduserbut);
                upduserbut.BringToFront();

                Button cancelbut = new Button
                {
                    Location = new Point(336, 55),
                    Text = "Отмена"
                };
                upduserpanel.Controls.Add(cancelbut);
                cancelbut.BringToFront();

                //фуекционал кнопки отмены

                void Clickcancelbut(object cancel, EventArgs cliclcancel)
                {
                    upduserpanel.Dispose();
                    Addbutton.Enabled = true;
                    DeleteUserBut.Enabled = true;
                    UpdateBut.Enabled = true;
                    NamelistBox.Enabled = true;
                }
                cancelbut.Click += Clickcancelbut;

                //Функционал кнопки обновить

                void Clickbut(object button, EventArgs click)
                {
                    if (namebox.Text != "" && carbohydbox.Text != "" && proteinbox.Text != "" && fatsbox.Text != "" && calloriesbox.Text != "" && numbereat.Text != "")
                    {
                        try
                        {
                            User newuser = (User)NamelistBox.SelectedItem;
                            newuser.Name = namebox.Text;
                            newuser.Edges.Carbohydrates = carbohydbox.Text;
                            newuser.Edges.Calloriesedge = calloriesbox.Text;
                            newuser.Edges.Fats = fatsbox.Text;
                            newuser.Edges.Proteins = proteinbox.Text;
                            newuser.Edges.Numbereats = Convert.ToInt32(numbereat.Text);

                            using (var db = new Aplicatincontext())
                            {

                                db.Users.Update(newuser);
                                db.Edges.Update(newuser.Edges);
                                db.SaveChanges();


                            }


                        }
                        catch (Exception)
                        {
                            MessageBox.Show("Неправильное значение");
                        }

                    }
                    else
                    {
                        MessageBox.Show("Заполните все поля!");

                    }
                    upduserpanel.Dispose();
                    Addbutton.Enabled = true;
                    DeleteUserBut.Enabled = true;
                    UpdateBut.Enabled = true;


                }
                upduserbut.Click += new EventHandler(Clickbut);
            }

            //Функционал кнопки "Удалить"

            DeleteUserBut.Click += DeleteUserButClick;
            void DeleteUserButClick(object but,EventArgs click)
            {
                DeleteUserBut.Enabled = true;
                Addbutton.Enabled = true;
                UpdateBut.Enabled = true;
                NamelistBox.Enabled = true;
                if (NamelistBox.SelectedItem != null)
                {
                    User seluser = (User)NamelistBox.SelectedItem;
                    using (var db = new Aplicatincontext())
                    {
                        db.Histories.RemoveRange(seluser.Histories);
                        db.Edges.Remove(seluser.Edges);
                        db.Users.Remove(seluser);
                        
                        db.SaveChanges();
                    }
                    NamelistBox.Items.Remove(seluser);
                }
                else { MessageBox.Show("Выберите пользователя!"); }
                return;
            }
        }

        //Функционал кнопки "Блюдо
        private void FoodBut_Click(object sender, EventArgs e)
        {
            Size = new Size(890, 520);
            UserBut.Hide();
            FoodBut.Hide();
            ClearFoodBut.Enabled = false;
            Eatbutton.Enabled = false;
            Historybutton.Enabled = false;


            Panel UserFoodPan = new Panel
            {
                Size = new Size(490, 40),
                Location = new Point(288, 10)

            };
            Controls.Add(UserFoodPan);

            Button AddFoodBut = new Button
            {
                Size = new Size(115, 40),
                Location = new Point(0),
                Text = "Добавить",
                FlatStyle = FlatStyle.Flat,
                BackColor = SystemColors.GradientActiveCaption,
                Cursor = Cursors.Hand,
                Font = new Font("Segoe Script", 8F, FontStyle.Bold, GraphicsUnit.Point),
                Margin = new Padding(0),



            };
            UserFoodPan.Controls.Add(AddFoodBut);
            AddFoodBut.FlatAppearance.BorderColor = Color.Blue;
            AddFoodBut.FlatAppearance.MouseDownBackColor = Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(64)))), ((int)(((byte)(0)))));
            AddFoodBut.FlatAppearance.MouseOverBackColor = Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(192)))), ((int)(((byte)(0)))));



            Button UpdateFoodBut = new Button
            {
                Size = new Size(115, 40),
                Location = new Point(120),
                Text = "Редактировать",
                FlatStyle = FlatStyle.Flat,
                BackColor = SystemColors.GradientActiveCaption,
                Cursor = Cursors.Hand,
                Font = new Font("Segoe Script", 8F, FontStyle.Bold, GraphicsUnit.Point),
                Margin = new Padding(0),
            };
            UserFoodPan.Controls.Add(UpdateFoodBut);
            UpdateFoodBut.FlatAppearance.BorderColor = Color.Blue;
            UpdateFoodBut.FlatAppearance.MouseDownBackColor = Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(64)))), ((int)(((byte)(0)))));
            UpdateFoodBut.FlatAppearance.MouseOverBackColor = Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(192)))), ((int)(((byte)(0)))));



            Button DeleteFoodBut = new Button
            {
                Size = new Size(115, 40),
                Location = new Point(240),
                Text = "Удалить",
                FlatStyle = FlatStyle.Flat,
                BackColor = SystemColors.GradientActiveCaption,
                Cursor = Cursors.Hand,
                Font = new Font("Segoe Script", 8F, FontStyle.Bold, GraphicsUnit.Point),
                Margin = new Padding(0),

            };
            UserFoodPan.Controls.Add(DeleteFoodBut);
            DeleteFoodBut.FlatAppearance.BorderColor = Color.Blue;
            DeleteFoodBut.FlatAppearance.MouseDownBackColor = Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(64)))), ((int)(((byte)(0)))));
            DeleteFoodBut.FlatAppearance.MouseOverBackColor = Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(192)))), ((int)(((byte)(0)))));


            Button CancelBut = new Button
            {
                Size = new Size(115, 40),
                Location = new Point(360),
                Text = "Отмена",
                FlatStyle = FlatStyle.Flat,
                BackColor = SystemColors.GradientActiveCaption,
                Cursor = Cursors.Hand,
                Font = new Font("Segoe Script", 8F, FontStyle.Bold, GraphicsUnit.Point),
                Margin = new Padding(0),


            };
            UserFoodPan.Controls.Add(CancelBut);
            CancelBut.FlatAppearance.BorderColor = Color.Blue;
            CancelBut.FlatAppearance.MouseDownBackColor = Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(64)))), ((int)(((byte)(0)))));
            CancelBut.FlatAppearance.MouseOverBackColor = Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(192)))), ((int)(((byte)(0)))));

            //Функционал кнопки "Добавить"

            AddFoodBut.Click += AddFoodButClick;
            void AddFoodButClick(object but, EventArgs click)
            {

            }

            //Функционал кнопки "Редактировать"

            UpdateFoodBut.Click += UpdFoodButClick;
            void UpdFoodButClick(object but, EventArgs click)
            {

            }

            //Функционал кнопки "Удалить"

            DeleteFoodBut.Click += DeleteFoodButClick;
            void DeleteFoodButClick(object but,EventArgs click)
            {

            }

            //Функционал кнопки "Отмена"

            CancelBut.Click += CancelButClick;
            void CancelButClick(object but, EventArgs click)
            {
                UserFoodPan.Dispose();
                ClearFoodBut.Enabled = true;
                Historybutton.Enabled = true;
                Eatbutton.Enabled = true;
                NamelistBox.Enabled = true;
                Size = new Size(890, 430);
                UserBut.Show();
                FoodBut.Show();
                if (Controls.ContainsKey("addfoodpanel"))
                {
                    Controls.RemoveByKey("addfoodpanel");
                }
                if (Controls.ContainsKey("updfoodpanel"))
                {
                    Controls.RemoveByKey("updfoodpanel");
                }

            }

        }
    }
}
