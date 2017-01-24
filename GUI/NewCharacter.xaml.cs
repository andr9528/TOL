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
    /// Interaction logic for NewCharacter.xaml
    /// </summary>
    public partial class NewCharacter : Window
    {
        public NewCharacter()
        {
            InitializeComponent();

            ArcheryWeightingValue.Text = "1";
            OneHandedWeightingValue.Text = "1";
            TwoHandedWeightingValue.Text = "1";
            LightArmorWeightingValue.Text = "1";
            HeavyArmorWeightingValue.Text = "1";
            StealthWeightingValue.Text = "1";
            AgilityWeightingValue.Text = "1";
            SmightingWeightingValue.Text = "1";
            AlchemyWeightingValue.Text = "1";
            EnchantingWeightingValue.Text = "1";
            BlockingWeightingValue.Text = "1";
            WildMagicWeightingValue.Text = "1";
            InfernoMagicWeightingValue.Text = "1";
            BlizzMagicWeightingValue.Text = "1";
            SkyMagicWeightingValue.Text = "1";
            PureMagicWeightingValue.Text = "1";

            PointsLeftValue.Text = "80";

            UpdatePointsLeft();

            ArcheryList.IsChecked = true;

        }

        private void CloseNewCharacter_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void ArcheryList_Checked(object sender, RoutedEventArgs e)
        {
            OneHandedList.IsChecked = false;
            TwoHandedList.IsChecked = false;
            LightArmorList.IsChecked = false;
            HeavyArmorList.IsChecked = false;
            StealthList.IsChecked = false;
            AgilityList.IsChecked = false;
            SmightingList.IsChecked = false;
            AlchemyList.IsChecked = false;
            EnchantingList.IsChecked = false;
            BlockingList.IsChecked = false;
            WildMagicList.IsChecked = false;
            InfernoMagicList.IsChecked = false;
            BlizzMagicList.IsChecked = false;
            SkyMagicList.IsChecked = false;
            PureMagicList.IsChecked = false;
        }

        private void OneHandedList_Checked(object sender, RoutedEventArgs e)
        {
            ArcheryList.IsChecked = false;
            TwoHandedList.IsChecked = false;
            LightArmorList.IsChecked = false;
            HeavyArmorList.IsChecked = false;
            StealthList.IsChecked = false;
            AgilityList.IsChecked = false;
            SmightingList.IsChecked = false;
            AlchemyList.IsChecked = false;
            EnchantingList.IsChecked = false;
            BlockingList.IsChecked = false;
            WildMagicList.IsChecked = false;
            InfernoMagicList.IsChecked = false;
            BlizzMagicList.IsChecked = false;
            SkyMagicList.IsChecked = false;
            PureMagicList.IsChecked = false;
        }

        private void TwoHandedList_Checked(object sender, RoutedEventArgs e)
        {
            ArcheryList.IsChecked = false;
            OneHandedList.IsChecked = false;
            LightArmorList.IsChecked = false;
            HeavyArmorList.IsChecked = false;
            StealthList.IsChecked = false;
            AgilityList.IsChecked = false;
            SmightingList.IsChecked = false;
            AlchemyList.IsChecked = false;
            EnchantingList.IsChecked = false;
            BlockingList.IsChecked = false;
            WildMagicList.IsChecked = false;
            InfernoMagicList.IsChecked = false;
            BlizzMagicList.IsChecked = false;
            SkyMagicList.IsChecked = false;
            PureMagicList.IsChecked = false;
        }

        private void LightArmorList_Checked(object sender, RoutedEventArgs e)
        {
            ArcheryList.IsChecked = false;
            OneHandedList.IsChecked = false;
            TwoHandedList.IsChecked = false;
            HeavyArmorList.IsChecked = false;
            StealthList.IsChecked = false;
            AgilityList.IsChecked = false;
            SmightingList.IsChecked = false;
            AlchemyList.IsChecked = false;
            EnchantingList.IsChecked = false;
            BlockingList.IsChecked = false;
            WildMagicList.IsChecked = false;
            InfernoMagicList.IsChecked = false;
            BlizzMagicList.IsChecked = false;
            SkyMagicList.IsChecked = false;
            PureMagicList.IsChecked = false;
        }

        private void HeavyArmorList_Checked(object sender, RoutedEventArgs e)
        {
            ArcheryList.IsChecked = false;
            OneHandedList.IsChecked = false;
            TwoHandedList.IsChecked = false;
            LightArmorList.IsChecked = false;
            StealthList.IsChecked = false;
            AgilityList.IsChecked = false;
            SmightingList.IsChecked = false;
            AlchemyList.IsChecked = false;
            EnchantingList.IsChecked = false;
            BlockingList.IsChecked = false;
            WildMagicList.IsChecked = false;
            InfernoMagicList.IsChecked = false;
            BlizzMagicList.IsChecked = false;
            SkyMagicList.IsChecked = false;
            PureMagicList.IsChecked = false;
        }

        private void StealthList_Checked(object sender, RoutedEventArgs e)
        {
            ArcheryList.IsChecked = false;
            OneHandedList.IsChecked = false;
            TwoHandedList.IsChecked = false;
            LightArmorList.IsChecked = false;
            HeavyArmorList.IsChecked = false;
            AgilityList.IsChecked = false;
            SmightingList.IsChecked = false;
            AlchemyList.IsChecked = false;
            EnchantingList.IsChecked = false;
            BlockingList.IsChecked = false;
            WildMagicList.IsChecked = false;
            InfernoMagicList.IsChecked = false;
            BlizzMagicList.IsChecked = false;
            SkyMagicList.IsChecked = false;
            PureMagicList.IsChecked = false;
        }

        private void AgilityList_Checked(object sender, RoutedEventArgs e)
        {
            ArcheryList.IsChecked = false;
            OneHandedList.IsChecked = false;
            TwoHandedList.IsChecked = false;
            LightArmorList.IsChecked = false;
            HeavyArmorList.IsChecked = false;
            StealthList.IsChecked = false;
            SmightingList.IsChecked = false;
            AlchemyList.IsChecked = false;
            EnchantingList.IsChecked = false;
            BlockingList.IsChecked = false;
            WildMagicList.IsChecked = false;
            InfernoMagicList.IsChecked = false;
            BlizzMagicList.IsChecked = false;
            SkyMagicList.IsChecked = false;
            PureMagicList.IsChecked = false;
        }

        private void SmightingList_Checked(object sender, RoutedEventArgs e)
        {
            ArcheryList.IsChecked = false;
            OneHandedList.IsChecked = false;
            TwoHandedList.IsChecked = false;
            LightArmorList.IsChecked = false;
            HeavyArmorList.IsChecked = false;
            StealthList.IsChecked = false;
            AgilityList.IsChecked = false;
            AlchemyList.IsChecked = false;
            EnchantingList.IsChecked = false;
            BlockingList.IsChecked = false;
            WildMagicList.IsChecked = false;
            InfernoMagicList.IsChecked = false;
            BlizzMagicList.IsChecked = false;
            SkyMagicList.IsChecked = false;
            PureMagicList.IsChecked = false;
        }

        private void AlchemyList_Checked(object sender, RoutedEventArgs e)
        {
            ArcheryList.IsChecked = false;
            OneHandedList.IsChecked = false;
            TwoHandedList.IsChecked = false;
            LightArmorList.IsChecked = false;
            HeavyArmorList.IsChecked = false;
            StealthList.IsChecked = false;
            AgilityList.IsChecked = false;
            SmightingList.IsChecked = false;
            EnchantingList.IsChecked = false;
            BlockingList.IsChecked = false;
            WildMagicList.IsChecked = false;
            InfernoMagicList.IsChecked = false;
            BlizzMagicList.IsChecked = false;
            SkyMagicList.IsChecked = false;
            PureMagicList.IsChecked = false;
        }

        private void EnchantingList_Checked(object sender, RoutedEventArgs e)
        {
            ArcheryList.IsChecked = false;
            OneHandedList.IsChecked = false;
            TwoHandedList.IsChecked = false;
            LightArmorList.IsChecked = false;
            HeavyArmorList.IsChecked = false;
            StealthList.IsChecked = false;
            AgilityList.IsChecked = false;
            SmightingList.IsChecked = false;
            AlchemyList.IsChecked = false;
            BlockingList.IsChecked = false;
            WildMagicList.IsChecked = false;
            InfernoMagicList.IsChecked = false;
            BlizzMagicList.IsChecked = false;
            SkyMagicList.IsChecked = false;
            PureMagicList.IsChecked = false;
        }

        private void BlockingList_Checked(object sender, RoutedEventArgs e)
        {
            ArcheryList.IsChecked = false;
            OneHandedList.IsChecked = false;
            TwoHandedList.IsChecked = false;
            LightArmorList.IsChecked = false;
            HeavyArmorList.IsChecked = false;
            StealthList.IsChecked = false;
            AgilityList.IsChecked = false;
            SmightingList.IsChecked = false;
            AlchemyList.IsChecked = false;
            EnchantingList.IsChecked = false;
            WildMagicList.IsChecked = false;
            InfernoMagicList.IsChecked = false;
            BlizzMagicList.IsChecked = false;
            SkyMagicList.IsChecked = false;
            PureMagicList.IsChecked = false;
        }

        private void WildMagicList_Checked(object sender, RoutedEventArgs e)
        {
            ArcheryList.IsChecked = false;
            OneHandedList.IsChecked = false;
            TwoHandedList.IsChecked = false;
            LightArmorList.IsChecked = false;
            HeavyArmorList.IsChecked = false;
            StealthList.IsChecked = false;
            AgilityList.IsChecked = false;
            SmightingList.IsChecked = false;
            AlchemyList.IsChecked = false;
            EnchantingList.IsChecked = false;
            BlockingList.IsChecked = false;
            InfernoMagicList.IsChecked = false;
            BlizzMagicList.IsChecked = false;
            SkyMagicList.IsChecked = false;
            PureMagicList.IsChecked = false;
        }

        private void InfernoMagicList_Checked(object sender, RoutedEventArgs e)
        {
            ArcheryList.IsChecked = false;
            OneHandedList.IsChecked = false;
            TwoHandedList.IsChecked = false;
            LightArmorList.IsChecked = false;
            HeavyArmorList.IsChecked = false;
            StealthList.IsChecked = false;
            AgilityList.IsChecked = false;
            SmightingList.IsChecked = false;
            AlchemyList.IsChecked = false;
            EnchantingList.IsChecked = false;
            BlockingList.IsChecked = false;
            WildMagicList.IsChecked = false;
            BlizzMagicList.IsChecked = false;
            SkyMagicList.IsChecked = false;
            PureMagicList.IsChecked = false;
        }

        private void BlizzMagicList_Checked(object sender, RoutedEventArgs e)
        {
            ArcheryList.IsChecked = false;
            OneHandedList.IsChecked = false;
            TwoHandedList.IsChecked = false;
            LightArmorList.IsChecked = false;
            HeavyArmorList.IsChecked = false;
            StealthList.IsChecked = false;
            AgilityList.IsChecked = false;
            SmightingList.IsChecked = false;
            AlchemyList.IsChecked = false;
            EnchantingList.IsChecked = false;
            BlockingList.IsChecked = false;
            WildMagicList.IsChecked = false;
            InfernoMagicList.IsChecked = false;
            SkyMagicList.IsChecked = false;
            PureMagicList.IsChecked = false;
        }

        private void SkyMagicList_Checked(object sender, RoutedEventArgs e)
        {
            ArcheryList.IsChecked = false;
            OneHandedList.IsChecked = false;
            TwoHandedList.IsChecked = false;
            LightArmorList.IsChecked = false;
            HeavyArmorList.IsChecked = false;
            StealthList.IsChecked = false;
            AgilityList.IsChecked = false;
            SmightingList.IsChecked = false;
            AlchemyList.IsChecked = false;
            EnchantingList.IsChecked = false;
            BlockingList.IsChecked = false;
            WildMagicList.IsChecked = false;
            InfernoMagicList.IsChecked = false;
            BlizzMagicList.IsChecked = false;
            PureMagicList.IsChecked = false;
        }

        private void PureMagicList_Checked(object sender, RoutedEventArgs e)
        {
            ArcheryList.IsChecked = false;
            OneHandedList.IsChecked = false;
            TwoHandedList.IsChecked = false;
            LightArmorList.IsChecked = false;
            HeavyArmorList.IsChecked = false;
            StealthList.IsChecked = false;
            AgilityList.IsChecked = false;
            SmightingList.IsChecked = false;
            AlchemyList.IsChecked = false;
            EnchantingList.IsChecked = false;
            BlockingList.IsChecked = false;
            WildMagicList.IsChecked = false;
            InfernoMagicList.IsChecked = false;
            BlizzMagicList.IsChecked = false;
            SkyMagicList.IsChecked = false;
        }

        private void IncreaseChecked_Click(object sender, RoutedEventArgs e)
        {
            int parseValue;
            ErrorBox.Text = "";

            if (int.Parse(PointsLeftValue.Text) == 0)
            {
                ErrorBox.Text = "Error 3";
            }
            else
            {
                if (ArcheryList.IsChecked == true && int.Parse(ArcheryWeightingValue.Text) != 10)
                {
                    int.TryParse(ArcheryWeightingValue.Text, out parseValue);
                    ArcheryWeightingValue.Text = "" + (parseValue + 1);
                }
                else if (OneHandedList.IsChecked == true && int.Parse(OneHandedWeightingValue.Text) != 10)
                {
                    int.TryParse(OneHandedWeightingValue.Text, out parseValue);
                    OneHandedWeightingValue.Text = "" + (parseValue + 1);
                }
                else if (TwoHandedList.IsChecked == true && int.Parse(TwoHandedWeightingValue.Text) != 10)
                {
                    int.TryParse(TwoHandedWeightingValue.Text, out parseValue);
                    TwoHandedWeightingValue.Text = "" + (parseValue + 1);
                }
                else if (LightArmorList.IsChecked == true && int.Parse(LightArmorWeightingValue.Text) != 10)
                {
                    int.TryParse(LightArmorWeightingValue.Text, out parseValue);
                    LightArmorWeightingValue.Text = "" + (parseValue + 1);
                }
                else if (HeavyArmorList.IsChecked == true && int.Parse(HeavyArmorWeightingValue.Text) != 10)
                {
                    int.TryParse(HeavyArmorWeightingValue.Text, out parseValue);
                    HeavyArmorWeightingValue.Text = "" + (parseValue + 1);
                }
                else if (StealthList.IsChecked == true && int.Parse(StealthWeightingValue.Text) != 10)
                {
                    int.TryParse(StealthWeightingValue.Text, out parseValue);
                    StealthWeightingValue.Text = "" + (parseValue + 1);
                }
                else if (AgilityList.IsChecked == true && int.Parse(AgilityWeightingValue.Text) != 10)
                {
                    int.TryParse(AgilityWeightingValue.Text, out parseValue);
                    AgilityWeightingValue.Text = "" + (parseValue + 1);
                }
                else if (SmightingList.IsChecked == true && int.Parse(SmightingWeightingValue.Text) != 10)
                {
                    int.TryParse(SmightingWeightingValue.Text, out parseValue);
                    SmightingWeightingValue.Text = "" + (parseValue + 1);
                }
                else if (EnchantingList.IsChecked == true && int.Parse(EnchantingWeightingValue.Text) != 10)
                {
                    int.TryParse(EnchantingWeightingValue.Text, out parseValue);
                    EnchantingWeightingValue.Text = "" + (parseValue + 1);
                }
                else if (AlchemyList.IsChecked == true && int.Parse(AlchemyWeightingValue.Text) != 10)
                {
                    int.TryParse(AlchemyWeightingValue.Text, out parseValue);
                    AlchemyWeightingValue.Text = "" + (parseValue + 1);
                }
                else if (BlockingList.IsChecked == true && int.Parse(BlockingWeightingValue.Text) != 10)
                {
                    int.TryParse(BlockingWeightingValue.Text, out parseValue);
                    BlockingWeightingValue.Text = "" + (parseValue + 1);
                }
                else if (WildMagicList.IsChecked == true && int.Parse(WildMagicWeightingValue.Text) != 10)
                {
                    int.TryParse(WildMagicWeightingValue.Text, out parseValue);
                    WildMagicWeightingValue.Text = "" + (parseValue + 1);
                }
                else if (InfernoMagicList.IsChecked == true && int.Parse(InfernoMagicWeightingValue.Text) != 10)
                {
                    int.TryParse(InfernoMagicWeightingValue.Text, out parseValue);
                    InfernoMagicWeightingValue.Text = "" + (parseValue +1);
                }
                else if (BlizzMagicList.IsChecked == true && int.Parse(BlizzMagicWeightingValue.Text) != 10)
                {
                    int.TryParse(BlizzMagicWeightingValue.Text, out parseValue);
                    BlizzMagicWeightingValue.Text = "" + (parseValue + 1);
                }
                else if (SkyMagicList.IsChecked == true && int.Parse(SkyMagicWeightingValue.Text) != 10)
                {
                    int.TryParse(SkyMagicWeightingValue.Text, out parseValue);
                    SkyMagicWeightingValue.Text = "" + (parseValue + 1);
                }
                else if (PureMagicList.IsChecked == true && int.Parse(PureMagicWeightingValue.Text) != 10)
                {
                    int.TryParse(PureMagicWeightingValue.Text, out parseValue);
                    PureMagicWeightingValue.Text = "" + (parseValue + 1);
                }
            }
            UpdatePointsLeft();
        }

        private void DecreaseChecked_Click(object sender, RoutedEventArgs e)
        {
            int parseValue;
            ErrorBox.Text = "";

            if (int.Parse(PointsLeftValue.Text) == 64)
            {
                ErrorBox.Text = "Error 2";
            }
            else
            {
                if (ArcheryList.IsChecked == true && int.Parse(ArcheryWeightingValue.Text) != 1)
                {
                    int.TryParse(ArcheryWeightingValue.Text, out parseValue);
                    ArcheryWeightingValue.Text = "" + (parseValue - 1);
                }
                else if (OneHandedList.IsChecked == true && int.Parse(OneHandedWeightingValue.Text) != 1)
                {
                    int.TryParse(OneHandedWeightingValue.Text, out parseValue);
                    OneHandedWeightingValue.Text = "" + (parseValue - 1);
                }
                else if (TwoHandedList.IsChecked == true && int.Parse(TwoHandedWeightingValue.Text) != 1)
                {
                    int.TryParse(TwoHandedWeightingValue.Text, out parseValue);
                    TwoHandedWeightingValue.Text = "" + (parseValue - 1);
                }
                else if (LightArmorList.IsChecked == true && int.Parse(LightArmorWeightingValue.Text) != 1)
                {
                    int.TryParse(LightArmorWeightingValue.Text, out parseValue);
                    LightArmorWeightingValue.Text = "" + (parseValue - 1);
                }
                else if (HeavyArmorList.IsChecked == true && int.Parse(HeavyArmorWeightingValue.Text) != 1)
                {
                    int.TryParse(HeavyArmorWeightingValue.Text, out parseValue);
                    HeavyArmorWeightingValue.Text = "" + (parseValue - 1);
                }
                else if (StealthList.IsChecked == true && int.Parse(StealthWeightingValue.Text) != 1)
                {
                    int.TryParse(StealthWeightingValue.Text, out parseValue);
                    StealthWeightingValue.Text = "" + (parseValue - 1);
                }
                else if (AgilityList.IsChecked == true && int.Parse(AgilityWeightingValue.Text) != 1)
                {
                    int.TryParse(AgilityWeightingValue.Text, out parseValue);
                    AgilityWeightingValue.Text = "" + (parseValue - 1);
                }
                else if (SmightingList.IsChecked == true && int.Parse(SmightingWeightingValue.Text) != 1)
                {
                    int.TryParse(SmightingWeightingValue.Text, out parseValue);
                    SmightingWeightingValue.Text = "" + (parseValue - 1);
                }
                else if (EnchantingList.IsChecked == true && int.Parse(EnchantingWeightingValue.Text) != 1)
                {
                    int.TryParse(EnchantingWeightingValue.Text, out parseValue);
                    EnchantingWeightingValue.Text = "" + (parseValue - 1);
                }
                else if (AlchemyList.IsChecked == true && int.Parse(AlchemyWeightingValue.Text) != 1)
                {
                    int.TryParse(AlchemyWeightingValue.Text, out parseValue);
                    AlchemyWeightingValue.Text = "" + (parseValue - 1);
                }
                else if (BlockingList.IsChecked == true && int.Parse(BlockingWeightingValue.Text) != 1)
                {
                    int.TryParse(BlockingWeightingValue.Text, out parseValue);
                    BlockingWeightingValue.Text = "" + (parseValue - 1);
                }
                else if (WildMagicList.IsChecked == true && int.Parse(WildMagicWeightingValue.Text) != 1)
                {
                    int.TryParse(WildMagicWeightingValue.Text, out parseValue);
                    WildMagicWeightingValue.Text = "" + (parseValue - 1);
                }
                else if (InfernoMagicList.IsChecked == true && int.Parse(InfernoMagicWeightingValue.Text) != 1)
                {
                    int.TryParse(InfernoMagicWeightingValue.Text, out parseValue);
                    InfernoMagicWeightingValue.Text = "" + (parseValue - 1);
                }
                else if (BlizzMagicList.IsChecked == true && int.Parse(BlizzMagicWeightingValue.Text) != 1)
                {
                    int.TryParse(BlizzMagicWeightingValue.Text, out parseValue);
                    BlizzMagicWeightingValue.Text = "" + (parseValue - 1);
                }
                else if (SkyMagicList.IsChecked == true && int.Parse(SkyMagicWeightingValue.Text) != 1)
                {
                    int.TryParse(SkyMagicWeightingValue.Text, out parseValue);
                    SkyMagicWeightingValue.Text = "" + (parseValue - 1);
                }
                else if (PureMagicList.IsChecked == true && int.Parse(PureMagicWeightingValue.Text) != 1)
                {
                    int.TryParse(PureMagicWeightingValue.Text, out parseValue);
                    PureMagicWeightingValue.Text = "" + (parseValue - 1);
                }
            }
            UpdatePointsLeft();
        }
        private void UpdatePointsLeft()
        {
            int endvalue = int.Parse(PointsLeftValue.Text);

            endvalue = 80 - int.Parse(ArcheryWeightingValue.Text) - int.Parse(OneHandedWeightingValue.Text)
                - int.Parse(TwoHandedWeightingValue.Text) - int.Parse(LightArmorWeightingValue.Text)
                - int.Parse(HeavyArmorWeightingValue.Text) - int.Parse(StealthWeightingValue.Text)
                - int.Parse(AgilityWeightingValue.Text) - int.Parse(SmightingWeightingValue.Text)
                - int.Parse(AlchemyWeightingValue.Text) - int.Parse(EnchantingWeightingValue.Text)
                - int.Parse(BlockingWeightingValue.Text) - int.Parse(WildMagicWeightingValue.Text)
                - int.Parse(InfernoMagicWeightingValue.Text) - int.Parse(BlizzMagicWeightingValue.Text)
                - int.Parse(SkyMagicWeightingValue.Text) - int.Parse(PureMagicWeightingValue.Text);

            PointsLeftValue.Text = "" + endvalue;
        }
    }
}
