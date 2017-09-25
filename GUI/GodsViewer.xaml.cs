using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using Library;

namespace GUI
{
    /// <summary>
    /// Interaction logic for Gods.xaml
    /// </summary>
    public partial class GodsViewer : Window
    {
        

        public GodsViewer()
        {
            InitializeComponent();
        }

        private void CloseDivine_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void DropDownDivine_Loaded(object sender, RoutedEventArgs e)
        {
            List<string> divinesS = new List<string>();

            foreach (Gods divine in Repo.AllDivines)
            {
                divinesS.Add(divine.Name);
            }

            var DropDownDivine = sender as ComboBox;

            DropDownDivine.ItemsSource = divinesS;

            DropDownDivine.SelectedIndex = 0;
        }

        private void DropDownDivine_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            int favorSum = 0;
            int xpSum = 0;

            if (DropDownDivine.SelectedIndex > Repo.AllDivines.Count)
            {
                ErrorBox.Text = "Error 1";
                SumFavorValue.Text = "";
                SumXpValue.Text = "";

                ArcheryWeightValue.Text = "";
                OneHandedWeightValue.Text = "";
                TwoHandedWeightValue.Text = "";
                LightArmorWeightValue.Text = "";
                HeavyArmorWeightValue.Text = "";
                StealthWeightValue.Text = "";
                AgilityWeightValue.Text = "";
                SmithingWeightValue.Text = "";
                EnchantingWeightValue.Text = "";
                AlchemyWeightValue.Text = "";
                BlockingWeightValue.Text = "";
                WildMagicWeightValue.Text = "";
                InfernoMagicWeightValue.Text = "";
                BlizzMagicWeightValue.Text = "";
                SkyMagicWeightValue.Text = "";
                PureMagicWeightValue.Text = "";

                ArcheryXpValue.Text = "";
                OneHandedXpValue.Text = "";
                TwoHandedXpValue.Text = "";
                LightArmorXpValue.Text = "";
                HeavyArmorXpValue.Text = "";
                StealthXpValue.Text = "";
                AgilityXpValue.Text = "";
                SmithingXpValue.Text = "";
                EnchantingXpValue.Text = "";
                AlchemyXpValue.Text = "";
                BlockingXpValue.Text = "";
                WildMagicXpValue.Text = "";
                InfernoMagicXpValue.Text = "";
                BlizzMagicXpValue.Text = "";
                SkyMagicXpValue.Text = "";
                PureMagicXpValue.Text = "";

            }
            else
            {
                ErrorBox.Text = "";

                ArcheryWeightValue.Text = "" + Repo.AllDivines[DropDownDivine.SelectedIndex].Favoring[0];
                OneHandedWeightValue.Text = "" + Repo.AllDivines[DropDownDivine.SelectedIndex].Favoring[1];
                TwoHandedWeightValue.Text = "" + Repo.AllDivines[DropDownDivine.SelectedIndex].Favoring[2];
                LightArmorWeightValue.Text = "" + Repo.AllDivines[DropDownDivine.SelectedIndex].Favoring[3];
                HeavyArmorWeightValue.Text = "" + Repo.AllDivines[DropDownDivine.SelectedIndex].Favoring[4];
                StealthWeightValue.Text = "" + Repo.AllDivines[DropDownDivine.SelectedIndex].Favoring[5];
                AgilityWeightValue.Text = "" + Repo.AllDivines[DropDownDivine.SelectedIndex].Favoring[6];
                SmithingWeightValue.Text = "" + Repo.AllDivines[DropDownDivine.SelectedIndex].Favoring[7];
                EnchantingWeightValue.Text = "" + Repo.AllDivines[DropDownDivine.SelectedIndex].Favoring[8];
                AlchemyWeightValue.Text = "" + Repo.AllDivines[DropDownDivine.SelectedIndex].Favoring[9];
                BlockingWeightValue.Text = "" + Repo.AllDivines[DropDownDivine.SelectedIndex].Favoring[10];
                WildMagicWeightValue.Text = "" + Repo.AllDivines[DropDownDivine.SelectedIndex].Favoring[11];
                InfernoMagicWeightValue.Text = "" + Repo.AllDivines[DropDownDivine.SelectedIndex].Favoring[12];
                BlizzMagicWeightValue.Text = "" + Repo.AllDivines[DropDownDivine.SelectedIndex].Favoring[13];
                SkyMagicWeightValue.Text = "" + Repo.AllDivines[DropDownDivine.SelectedIndex].Favoring[14];
                PureMagicWeightValue.Text = "" + Repo.AllDivines[DropDownDivine.SelectedIndex].Favoring[15];

                foreach (int favor in Repo.AllDivines[DropDownDivine.SelectedIndex].Favoring)
                {
                    favorSum += favor;
                }

                SumFavorValue.Text = "" + favorSum;

                ArcheryXpValue.Text = "" + Repo.AllDivines[DropDownDivine.SelectedIndex].XpModifier[0]; 
                OneHandedXpValue.Text = "" + Repo.AllDivines[DropDownDivine.SelectedIndex].XpModifier[1];
                TwoHandedXpValue.Text = "" + Repo.AllDivines[DropDownDivine.SelectedIndex].XpModifier[2];
                LightArmorXpValue.Text = "" + Repo.AllDivines[DropDownDivine.SelectedIndex].XpModifier[3];
                HeavyArmorXpValue.Text = "" + Repo.AllDivines[DropDownDivine.SelectedIndex].XpModifier[4];
                StealthXpValue.Text = "" + Repo.AllDivines[DropDownDivine.SelectedIndex].XpModifier[5];
                AgilityXpValue.Text = "" + Repo.AllDivines[DropDownDivine.SelectedIndex].XpModifier[6];
                SmithingXpValue.Text = "" + Repo.AllDivines[DropDownDivine.SelectedIndex].XpModifier[7];
                EnchantingXpValue.Text = "" + Repo.AllDivines[DropDownDivine.SelectedIndex].XpModifier[8];
                AlchemyXpValue.Text = "" + Repo.AllDivines[DropDownDivine.SelectedIndex].XpModifier[9];
                BlockingXpValue.Text = "" + Repo.AllDivines[DropDownDivine.SelectedIndex].XpModifier[10];
                WildMagicXpValue.Text = "" + Repo.AllDivines[DropDownDivine.SelectedIndex].XpModifier[11];
                InfernoMagicXpValue.Text = "" + Repo.AllDivines[DropDownDivine.SelectedIndex].XpModifier[12];
                BlizzMagicXpValue.Text = "" + Repo.AllDivines[DropDownDivine.SelectedIndex].XpModifier[13];
                SkyMagicXpValue.Text = "" + Repo.AllDivines[DropDownDivine.SelectedIndex].XpModifier[14];
                PureMagicXpValue.Text = "" + Repo.AllDivines[DropDownDivine.SelectedIndex].XpModifier[15];

                foreach (int xp in Repo.AllDivines[DropDownDivine.SelectedIndex].XpModifier)
                {
                    xpSum += xp;
                }

                SumXpValue.Text = "" + xpSum;

                //DropDownXpCheck.ItemsSource = divines[DropDownDivine.SelectedIndex].XpModifier;

                //DropDownXpCheck.SelectedIndex = 0;
            }
        }

        //private void DropDownXpCheck_Loaded(object sender, RoutedEventArgs e)
        //{
        //    var DropDownXpCheck = sender as ComboBox;

        //    DropDownXpCheck.ItemsSource = divines[DropDownDivine.SelectedIndex].XpModifier;

        //    DropDownXpCheck.SelectedIndex = 0;
        //}
    }
}
