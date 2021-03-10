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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace ProjectGUINoninteractive
{
    //public class Product
    //{
    //    public string Name;
    //    public string Description;
    //    public int Price;
    //    public string Path;
    //}
    public partial class MainWindow : Window
    {
        //private StackPanel productPanel;

        public MainWindow()
        {
            InitializeComponent();
            Start();
        }

        private void Start()
        {
            string[] productImagePath = { "cat-1.jpg", "cat-2.jpg", "cat-3.jpg", "cat-4.jpg" };
            string productName = "Dator";
            string productDescription = "Contains a CPU, and a whole lot of other stuff.";
            string productPrice = "1500";
            // Window options
            Title = "GUI App";
            Width = 600;
            Height = 1000;
            WindowStartupLocation = WindowStartupLocation.CenterScreen;

            // Scrolling
            ScrollViewer root = new ScrollViewer();
            root.VerticalScrollBarVisibility = ScrollBarVisibility.Auto;
            Content = root;

            // Main grid
            StackPanel stack = new StackPanel
            {
                Orientation = Orientation.Vertical,
                Margin = new Thickness(5)
            };
            root.Content = stack;
            //Grid grid = new Grid();
            //root.Content = grid;
            //grid.Margin = new Thickness(5);

            //grid.RowDefinitions.Add(new RowDefinition { Height = GridLength.Auto });
            //grid.RowDefinitions.Add(new RowDefinition { Height = GridLength.Auto });
            //grid.RowDefinitions.Add(new RowDefinition { Height = GridLength.Auto });
            //grid.RowDefinitions.Add(new RowDefinition { Height = GridLength.Auto });
            //grid.RowDefinitions.Add(new RowDefinition { Height = GridLength.Auto });
            //grid.ColumnDefinitions.Add(new ColumnDefinition { Width = GridLength.Auto });

            WrapPanel wrap = new WrapPanel
            {
                Orientation = Orientation.Horizontal
            };

            //root.Content = wrap;
            stack.Children.Add(wrap);
            //grid.Children.Add(wrap);
            //Grid.SetColumn(wrap, 0);
            //Grid.SetRow(wrap, 0);

            wrap.Children.Add(CreateProductgrid(productImagePath[0], productName, productDescription, productPrice));
            wrap.Children.Add(CreateProductgrid(productImagePath[1], productName, productDescription, productPrice));
            wrap.Children.Add(CreateProductgrid(productImagePath[2], productName, productDescription, productPrice));
            wrap.Children.Add(CreateProductgrid(productImagePath[3], productName, productDescription, productPrice));

            stack.Children.Add(CreateAddProductGrid(productName, 4));
            stack.Children.Add(CreateAddProductGrid(productName, 2));
            stack.Children.Add(CreateAddProductGrid(productName, 1));
            stack.Children.Add(CreateAddProductGrid(productName, 3));

            Grid cartGrid = new Grid();
            cartGrid.RowDefinitions.Add(new RowDefinition { Height = GridLength.Auto });
            cartGrid.ColumnDefinitions.Add(new ColumnDefinition());
            cartGrid.ColumnDefinitions.Add(new ColumnDefinition());
            cartGrid.ColumnDefinitions.Add(new ColumnDefinition());
            stack.Children.Add(cartGrid);

            Button saveCartButton = CreateButton("Spara kundvagnen");
            cartGrid.Children.Add(saveCartButton);
            Grid.SetRow(saveCartButton, 0);
            Grid.SetColumn(saveCartButton, 0);

            Button emptyCartButton = CreateButton("Töm kundvagnen");
            cartGrid.Children.Add(emptyCartButton);
            Grid.SetRow(emptyCartButton, 0);
            Grid.SetColumn(emptyCartButton, 1);

            Button confirmOrderButton = CreateButton("Avsluta köp");
            cartGrid.Children.Add(confirmOrderButton);
            Grid.SetRow(confirmOrderButton, 0);
            Grid.SetColumn(confirmOrderButton, 2);

            Grid rebateCodeGrid = new Grid();
            rebateCodeGrid.RowDefinitions.Add(new RowDefinition { Height = GridLength.Auto });
            rebateCodeGrid.ColumnDefinitions.Add(new ColumnDefinition());
            rebateCodeGrid.ColumnDefinitions.Add(new ColumnDefinition());
            rebateCodeGrid.ColumnDefinitions.Add(new ColumnDefinition());
            stack.Children.Add(rebateCodeGrid);

            Label rebateCodeLabel = CreateLabel("Rabattkod");
            rebateCodeGrid.Children.Add(rebateCodeLabel);
            Grid.SetRow(rebateCodeLabel, 0);
            Grid.SetColumn(rebateCodeLabel, 0);

            TextBox rebateCodeTextBox = new TextBox
            {
                Margin = new Thickness(5)
            };
            rebateCodeGrid.Children.Add(rebateCodeTextBox);
            Grid.SetRow(rebateCodeTextBox, 0);
            Grid.SetColumn(rebateCodeTextBox, 1);

            Button confirmRebateCodeButton = CreateButton("OK");
            rebateCodeGrid.Children.Add(confirmRebateCodeButton);
            Grid.SetRow(confirmRebateCodeButton, 0);
            Grid.SetColumn(confirmRebateCodeButton, 2);

            Grid sumPurchaseGrid = new Grid();
            sumPurchaseGrid.RowDefinitions.Add(new RowDefinition { Height = GridLength.Auto });
            sumPurchaseGrid.ColumnDefinitions.Add(new ColumnDefinition());
            stack.Children.Add(sumPurchaseGrid);

            int sumPurchase = int.Parse(productPrice);
            Label sumPurchaseLabel = CreateLabel("Sum: " + productPrice);
            sumPurchaseGrid.Children.Add(sumPurchaseLabel);
            Grid.SetRow(sumPurchaseLabel, 0);
            Grid.SetColumn(sumPurchaseLabel, 0);
        }

        public static Grid CreateAddProductGrid(string productName, int quantity)
        {
            string plus = "+";
            string minus = "-";
            string delete = "Ta bort";

            Grid addProductGrid = new Grid();
            addProductGrid.RowDefinitions.Add(new RowDefinition { Height = GridLength.Auto });
            addProductGrid.ColumnDefinitions.Add(new ColumnDefinition { Width = GridLength.Auto });
            addProductGrid.ColumnDefinitions.Add(new ColumnDefinition { Width = GridLength.Auto });
            addProductGrid.ColumnDefinitions.Add(new ColumnDefinition { Width = GridLength.Auto });
            addProductGrid.ColumnDefinitions.Add(new ColumnDefinition { Width = GridLength.Auto });
            addProductGrid.ColumnDefinitions.Add(new ColumnDefinition { Width = GridLength.Auto });

            Label productNameLabel = CreateLabel(productName);
            addProductGrid.Children.Add(productNameLabel);
            Grid.SetRow(productNameLabel, 0);
            Grid.SetColumn(productNameLabel, 0);

            Label quantityLabel = CreateLabel(quantity.ToString());
            addProductGrid.Children.Add(quantityLabel);
            Grid.SetRow(quantityLabel, 0);
            Grid.SetColumn(quantityLabel, 1);

            Button plusButton = CreateButton(plus);
            addProductGrid.Children.Add(plusButton);
            Grid.SetRow(plusButton, 0);
            Grid.SetColumn(plusButton, 2);

            Button minusButton = CreateButton(minus);
            addProductGrid.Children.Add(minusButton);
            Grid.SetRow(minusButton, 0);
            Grid.SetColumn(minusButton, 3);

            Button deleteButton = CreateButton(delete);
            addProductGrid.Children.Add(deleteButton);
            Grid.SetRow(deleteButton, 0);
            Grid.SetColumn(deleteButton, 4);

            return addProductGrid;
        }

        public static StackPanel CreateProductgrid(string productImagePath, string productName, string productDescription, string productPrice)
        {
            string addButton = "Lägg till";

            StackPanel productStackPanel = new StackPanel
            {
                Orientation = Orientation.Vertical,
                Margin = new Thickness(5)
            };
            //Grid productGrid = new Grid();
            //productGrid.RowDefinitions.Add(new RowDefinition { Height = GridLength.Auto });
            //productGrid.RowDefinitions.Add(new RowDefinition { Height = GridLength.Auto });
            //productGrid.RowDefinitions.Add(new RowDefinition { Height = GridLength.Auto });
            //productGrid.RowDefinitions.Add(new RowDefinition { Height = GridLength.Auto });
            //productGrid.RowDefinitions.Add(new RowDefinition { Height = GridLength.Auto });
            //productGrid.ColumnDefinitions.Add(new ColumnDefinition { Width = GridLength.Auto });

            ImageSource source = new BitmapImage(new Uri(productImagePath, UriKind.Relative));
            Image image = new Image
            {
                Source = source,
                Width = 150,
                Height = 150,
                Stretch = Stretch.UniformToFill,
                HorizontalAlignment = HorizontalAlignment.Center,
                VerticalAlignment = VerticalAlignment.Center,
                Margin = new Thickness(5)
            };

            productStackPanel.Children.Add(image);
            Label productNameLabel = CreateLabel(productName);
            productStackPanel.Children.Add(productNameLabel);
            Label productDescriptionLabel = CreateLabel(productDescription);
            productStackPanel.Children.Add(productDescriptionLabel);
            Label productPriceLabel = CreateLabel(productPrice);
            productStackPanel.Children.Add(productPriceLabel);
            Button button = CreateButton(addButton);
            productStackPanel.Children.Add(button);
            //productGrid.Children.Add(image);
            //Grid.SetRow(image, 0);
            //Grid.SetColumn(image, 0);

            //Label productNameLabel = CreateLabel(productName);
            //productGrid.Children.Add(productNameLabel);
            //Grid.SetRow(productNameLabel, 1);
            //Grid.SetColumn(productNameLabel, 0);

            //Label productDescriptionLabel = CreateLabel(productDescription);
            //productGrid.Children.Add(productDescriptionLabel);
            //Grid.SetRow(productDescriptionLabel, 2);
            //Grid.SetColumn(productDescriptionLabel, 0);

            //Label productPriceLabel = CreateLabel(productPrice);
            //productGrid.Children.Add(productPriceLabel);
            //Grid.SetRow(productPriceLabel, 3);
            //Grid.SetColumn(productPriceLabel, 0);

            //Button button = CreateButton(addButton);
            //productGrid.Children.Add(button);
            //Grid.SetRow(button, 4);
            //Grid.SetColumn(button, 0);

            return productStackPanel;
        }
        public static Label CreateLabel(string header)
        {
            Label label = new Label
            {
                Content = header,
                HorizontalContentAlignment = HorizontalAlignment.Left,
                Margin = new Thickness(5, 0, 0, 0),
                Padding = new Thickness(1)
            };
            return label;
        }
        public static Button CreateButton(string header)
        {
            Button button = new Button
            {
                Content = header,
                Margin = new Thickness(5),
                Padding = new Thickness(5)
            };
            return button;
        }
    }
}
