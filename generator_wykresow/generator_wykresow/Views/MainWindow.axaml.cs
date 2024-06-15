using System;
using System.Drawing;
using Avalonia;
using Avalonia.Controls;
using Avalonia.Interactivity;
using Avalonia.Markup.Xaml;
using System.Collections.Generic;

namespace generator_wykresow.Views
{
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
#if DEBUG
            this.AttachDevTools();
#endif
        }

        private void InitializeComponent()
        {
            AvaloniaXamlLoader.Load(this);
        }
        string rodzajWykresu = string.Empty;
        private void FunChosen()
        {
            this.FindControl<Button>("sin").IsVisible = false;
            this.FindControl<Button>("cos").IsVisible = false;
            this.FindControl<Button>("tg").IsVisible = false;
            this.FindControl<Button>("ctg").IsVisible = false;
            this.FindControl<Button>("start").IsVisible = false;
            this.FindControl<TextBlock>("tekst").IsVisible = false;
            this.FindControl<Button>("powrot").IsVisible = true;
            this.FindControl<TextBlock>("tekst1").IsVisible = true;
            this.FindControl<TextBox>("inputTextBox1").IsVisible = true;
            this.FindControl<TextBox>("inputTextBox2").IsVisible = true;
            this.FindControl<TextBox>("inputTextBox3").IsVisible = true;
            this.FindControl<TextBox>("inputTextBox4").IsVisible = true;
            this.FindControl<TextBlock>("a").IsVisible = true;
            this.FindControl<TextBlock>("b").IsVisible = true;
            this.FindControl<TextBlock>("c").IsVisible = true;
            this.FindControl<TextBlock>("d").IsVisible = true;
            this.FindControl<Button>("generuj").IsVisible = true;
            this.FindControl<TextBlock>("pattern").IsVisible = true;
        }

        private void StartButton_Click(object sender, RoutedEventArgs e)
        {
            if (this.FindControl<Button>("start").Content == "ROZPOCZNIJ")
            {
                this.FindControl<Button>("sin").IsVisible = true;
                this.FindControl<Button>("cos").IsVisible = true;
                this.FindControl<Button>("tg").IsVisible = true;
                this.FindControl<Button>("ctg").IsVisible = true;
                this.FindControl<Button>("start").Content = "POWRÓT";
                this.FindControl<TextBlock>("tekst").Text = "WYBIERZ RODZAJ FUNKCJI";
                this.FindControl<Button>("exit").IsVisible = false;
            }
            else
            {
                this.FindControl<Button>("sin").IsVisible = false;
                this.FindControl<Button>("cos").IsVisible = false;
                this.FindControl<Button>("tg").IsVisible = false;
                this.FindControl<Button>("ctg").IsVisible = false;
                this.FindControl<Button>("start").Content = "ROZPOCZNIJ";
                this.FindControl<TextBlock>("tekst").Text = "GENERATOR WYKRESÓW";
                this.FindControl<Button>("exit").IsVisible = true;
            }
        }

        private void SinButton_Click(object sender, RoutedEventArgs e)
        {
            FunChosen();
            rodzajWykresu = "sin";
            this.FindControl<TextBlock>("pattern").Text = "Wzór: y = a*sin(b*x+cπ)+d,\nwartości domyślne:\n-a - 1,\n-b - 1,\n-c - 0,\n-d - 0.\nUłamki należy wprowadzać w formacie dziesiętnym.";
        }

        private void CosButton_Click(object sender, RoutedEventArgs e)
        {
            FunChosen();
            rodzajWykresu = "cos";
            this.FindControl<TextBlock>("pattern").Text = "Wzór: y = a*cos(b*x+cπ)+d,\nwartości domyślne:\n-a - 1,\n-b - 1,\n-c - 0,\n-d - 0.\nUłamki należy wprowadzać w formacie dziesiętnym.";
        }

        private void TgButton_Click(object sender, RoutedEventArgs e)
        {
            FunChosen();
            rodzajWykresu = "tg";
            this.FindControl<TextBlock>("pattern").Text = "Wzór: y = a*tg(b*x+cπ)+d,\nwartości domyślne:\n-a - 1,\n-b - 1,\n-c - 0,\n-d - 0.\nUłamki należy wprowadzać w formacie dziesiętnym.";
        }

        private void CtgButton_Click(object sender, RoutedEventArgs e)
        {
            FunChosen();
            rodzajWykresu = "ctg";
            this.FindControl<TextBlock>("pattern").Text = "Wzór: y = a*ctg(b*x+cπ)+d,\nwartości domyślne:\n-a - 1,\n-b - 1,\n-c - 0,\n-d - 0.\nUłamki należy wprowadzać w formacie dziesiętnym.";
        }

        private void BackButton_Click(object sender, RoutedEventArgs e)
        {
            this.FindControl<Button>("sin").IsVisible = true;
            this.FindControl<Button>("cos").IsVisible = true;
            this.FindControl<Button>("tg").IsVisible = true;
            this.FindControl<Button>("ctg").IsVisible = true;
            this.FindControl<Button>("start").IsVisible = true;
            this.FindControl<TextBlock>("tekst").IsVisible = true;
            this.FindControl<Button>("powrot").IsVisible = false;
            this.FindControl<TextBlock>("tekst1").IsVisible = false;
            this.FindControl<TextBox>("inputTextBox1").IsVisible = false;
            this.FindControl<TextBox>("inputTextBox2").IsVisible = false;
            this.FindControl<TextBox>("inputTextBox3").IsVisible = false;
            this.FindControl<TextBox>("inputTextBox4").IsVisible = false;
            this.FindControl<TextBox>("inputTextBox1").Text = "";
            this.FindControl<TextBox>("inputTextBox2").Text = "";
            this.FindControl<TextBox>("inputTextBox3").Text = "";
            this.FindControl<TextBox>("inputTextBox4").Text = "";
            this.FindControl<TextBlock>("a").IsVisible = false;
            this.FindControl<TextBlock>("b").IsVisible = false;
            this.FindControl<TextBlock>("c").IsVisible = false;
            this.FindControl<TextBlock>("d").IsVisible = false;
            this.FindControl<Button>("generuj").IsVisible = false;
            this.FindControl<TextBlock>("pattern").Text = "";
            this.FindControl<TextBlock>("pattern").IsVisible = false;
            rodzajWykresu = string.Empty;
            this.FindControl<TextBlock>("status").IsVisible = false;
            this.FindControl<TextBlock>("status").Text = "";
        }

        private async void GenerateButton_Click(object sender, RoutedEventArgs e)
        {
            string a = "1";
            string b = "1";
            string c = "0";
            string d = "0";
            if (!string.IsNullOrWhiteSpace(this.FindControl<TextBox>("inputTextBox1").Text))
            {
                a = this.FindControl<TextBox>("inputTextBox1").Text;
            }
            if (!string.IsNullOrWhiteSpace(this.FindControl<TextBox>("inputTextBox2").Text))
            {
                b = this.FindControl<TextBox>("inputTextBox2").Text;
            }
            if (!string.IsNullOrWhiteSpace(this.FindControl<TextBox>("inputTextBox3").Text))
            {
                c = this.FindControl<TextBox>("inputTextBox3").Text;
            }
            if (!string.IsNullOrWhiteSpace(this.FindControl<TextBox>("inputTextBox4").Text))
            {
                d = this.FindControl<TextBox>("inputTextBox4").Text;
            }
            bool isAFloat = float.TryParse(a, out float floatA);
            bool isBFloat = float.TryParse(b, out float floatB);
            bool isCFloat = float.TryParse(c, out float floatC);
            bool isDFloat = float.TryParse(d, out float floatD);
            if (isAFloat && isBFloat && isCFloat && isDFloat && floatA != 0 && floatB != 0)
            {
                // Create SaveFileDialog
                var saveFileDialog = new SaveFileDialog
                {
                    DefaultExtension = "png",
                    Filters = new List<FileDialogFilter>
            {
                new FileDialogFilter { Name = "PNG Files", Extensions = { "png" } }
            }
                };

                // Show SaveFileDialog
                var filePath = await saveFileDialog.ShowAsync(this);

                if (filePath != null)
                {
                    // Generate the plot and save it to the selected file
                    int width = 2400;
                    int height = 1600;
                    int margin = 100;
                    int xScale = 100; // Scale factor for x-axis (radians)
                    int yScale = 100; // Scale factor for y-axis
                    using (var bitmap = new Bitmap(width, height))
                    {
                        using (var graphics = Graphics.FromImage(bitmap))
                        {
                            graphics.Clear(Color.White);
                            Pen pen = new Pen(Color.Black, 2);

                            // Draw axes
                            int xAxisYPosition = height / 2;
                            int yAxisXPosition = width / 2;
                            graphics.DrawLine(pen, margin, xAxisYPosition, width - margin, xAxisYPosition); // X axis
                            graphics.DrawLine(pen, yAxisXPosition, margin, yAxisXPosition, height - margin); // Y axis

                            // Draw labels
                            Font font = new Font("Arial", 16);
                            Brush brush = Brushes.Black;

                            // Draw axis end labels
                            graphics.DrawString("x", font, brush, width - margin + 10, xAxisYPosition - 10);
                            graphics.DrawString("y", font, brush, yAxisXPosition + 10, margin - 30);

                            // X-axis labels (in radians, from -6π to 6π, skip 0)
                            for (int i = -10; i <= 10; i++)
                            {
                                if (i != 0)
                                {
                                    string label = $"{i}π";
                                    int labelX = yAxisXPosition + (i * xScale) - 20;
                                    int labelY = xAxisYPosition + 10;
                                    graphics.DrawString(label, font, brush, labelX, labelY);
                                    // Draw tick mark
                                    graphics.DrawLine(pen, labelX + 20, xAxisYPosition - 5, labelX + 20, xAxisYPosition + 5);
                                }
                            }

                            // Y-axis labels (integers, from -6 to 6)
                            for (int i = -6; i <= 6; i++)
                            {
                                string label = $"{i}";
                                int labelX = yAxisXPosition - 40;
                                int labelY = xAxisYPosition - (i * yScale) - 10;
                                graphics.DrawString(label, font, brush, labelX, labelY);
                                // Draw tick mark
                                graphics.DrawLine(pen, yAxisXPosition - 5, labelY + 10, yAxisXPosition + 5, labelY + 10);
                            }

                            // Plot the function
                            pen.Color = Color.Blue;
                            for (float x = -12 * (float)Math.PI; x <= 12 * (float)Math.PI; x += 0.0001f)
                            {
                                float y = 0;
                                if (rodzajWykresu == "sin")
                                {
                                    y = floatA * (float)Math.Sin(floatB * x + floatC * (float)Math.PI) + floatD;
                                }
                                if (rodzajWykresu == "cos")
                                {
                                    y = floatA * (float)Math.Cos(floatB * x + floatC * (float)Math.PI) + floatD;
                                }
                                if (rodzajWykresu == "tg")
                                {
                                    y = floatA * (float)Math.Tan(floatB * x + floatC * (float)Math.PI) + floatD;
                                }
                                if (rodzajWykresu == "ctg")
                                {
                                    y = 1/(floatA * (float)Math.Tan(floatB * x + floatC * (float)Math.PI) + floatD);
                                }
                                int plotX = yAxisXPosition + (int)(x * xScale / Math.PI);
                                int plotY = xAxisYPosition - (int)(y * yScale);
                                if (plotX >= margin && plotX < width - margin && plotY >= margin && plotY < height - margin)
                                {
                                    bitmap.SetPixel(plotX, plotY, Color.Blue);
                                }
                            }
                        }

                        // Save the plot to the selected file
                        bitmap.Save(filePath, System.Drawing.Imaging.ImageFormat.Png);

                        // Display the path to the user
                        this.FindControl<TextBlock>("status").Text = "Wykres został zapisany w podanej ścieżce";
                        this.FindControl<TextBlock>("status").IsVisible = true;
                    }
                }
            }
            else
            {
                this.FindControl<TextBlock>("status").Text = "Niepoprawne dane, spróbuj ponownie";
                this.FindControl<TextBlock>("status").IsVisible = true;
            }
        }
        private void ExitButton_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
}
