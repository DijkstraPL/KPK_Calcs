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
using System.Net;
using System.Runtime.Serialization;
using TestData.MyRef;


namespace TestData
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void btnSoapCall_Click(object sender, RoutedEventArgs e)
        {
            using (ServiceClient ProxySoap = new ServiceClient())
            {
                dgEmpSoap.ItemsSource = ProxySoap.GetMaterialWeights();
            }
        }

        private void btnRestCall_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                ServiceRestClient ProxyRest = new ServiceRestClient();
                dgEmpRest.ItemsSource = ProxyRest.GetMaterialWeights();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, ex.GetType().Name);
            }

        }

        private void btnClear_Click(object sender, RoutedEventArgs e)
        {
            dgEmpSoap.ItemsSource = null;
            dgEmpRest.ItemsSource = null;
        }

        private void btnRestJsonCall_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                ServiceRestClient ProxyRest = new ServiceRestClient();
                dgEmpRest.ItemsSource = ProxyRest.GetMaterialWeightsJson();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, ex.GetType().Name);
            }

        }

        private void addNewMat_Click(object sender, RoutedEventArgs e)
        {
            using (ServiceClient ProxySoap = new ServiceClient())
            {
                var newMat = new MaterialWeight()
                {
                    MatWeightNo = Convert.ToInt32(matWeightNo.Text),
                    MaterialName = matName.Text,
                    MinimumWeight = Convert.ToDouble(minWeight.Text),
                    MaximumWeight = Convert.ToDouble(maxWeight.Text),
                };
                ProxySoap.InsertMaterialWeight(newMat);
            }
        }

        private void deleteNewMat_Click(object sender, RoutedEventArgs e)
        {
            using (ServiceClient ProxySoap = new ServiceClient())
            {
                var MatWeightNo = Convert.ToInt32(matWeightNo.Text);
                ProxySoap.DeleteMaterialWeight(MatWeightNo);
            }
        }

        private void loadMat_Click(object sender, RoutedEventArgs e)
        {
            using (ServiceClient ProxySoap = new ServiceClient())
            {
                var MatWeightNo = Convert.ToInt32(matWeightNo.Text);
                var matWeight = ProxySoap.SelectMaterialWeight(MatWeightNo);

                matName.Text = matWeight.MaterialName;
                minWeight.Text = Convert.ToString(matWeight.MinimumWeight);
                maxWeight.Text = Convert.ToString(matWeight.MaximumWeight);
            }
        }

        private void replaceMat_Click(object sender, RoutedEventArgs e)
        {
            using (ServiceClient ProxySoap = new ServiceClient())
            {
                var newMat = new MaterialWeight()
                {
                    MatWeightNo = Convert.ToInt32(matWeightNo.Text),
                    MaterialName = matName.Text,
                    MinimumWeight = Convert.ToDouble(minWeight.Text),
                    MaximumWeight = Convert.ToDouble(maxWeight.Text),
                };

                var MatWeightNo = Convert.ToInt32(matWeightNo.Text);

                ProxySoap.UpdateMaterialWeight(MatWeightNo, newMat);
            }
        }

       
    }
}
