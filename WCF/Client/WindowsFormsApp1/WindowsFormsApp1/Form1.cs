using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.ServiceModel;


namespace WindowsFormsApp1
{
    public partial class Form1 : Form
    {
        //AboutSQL aboutSQL;

        const string address= "net.tcp://localhost:8080/ServiceSQL/";
        IMySQL channel;
        ChannelFactory<IMySQL> factory;

        [ServiceContract]
        public interface IMySQL
        {
            [OperationContract]
            void Connect();
            [OperationContract]
            void CreateDB();
            [OperationContract]
            void CreateTable();
            [OperationContract]
            void InsertTable(int grade, int cclass, int no, string name, string score);//Create
            [OperationContract]
            DataTable ISelectTable();//Read
            [OperationContract]
            void UpdataTable(DataTable dataTable);//Update
            [OperationContract]
            void DeleteTable(string grade);//Remove

        }
        public Form1()
        {
            InitializeComponent();
        }

        private void btn_Read_Click(object sender, EventArgs e)
        {
            try
            {
                load_factory();
                DataTable tempTable = channel.ISelectTable();
                dataGridView1.DataSource = tempTable;
                ((ICommunicationObject)channel).Close();

            }
            catch(EndpointNotFoundException ex)
            {
                load_failed();
            }

        }

        private void btn_Create_Click(object sender, EventArgs e)
        {
            try
            {
                load_factory();
                channel.InsertTable(Convert.ToInt32(dataGridView1.Rows[dataGridView1.Rows.Count - 2].Cells[0].Value.ToString()),
                    Convert.ToInt32(dataGridView1.Rows[dataGridView1.Rows.Count - 2].Cells[1].Value.ToString()),
                    Convert.ToInt32(dataGridView1.Rows[dataGridView1.Rows.Count - 2].Cells[2].Value.ToString()),
                    dataGridView1.Rows[dataGridView1.Rows.Count - 2].Cells[3].Value.ToString(),
                    dataGridView1.Rows[dataGridView1.Rows.Count - 2].Cells[4].Value.ToString()
                    );
                ((ICommunicationObject)channel).Close();
                MessageBox.Show("입력되었습니다.");
            }
            catch(EndpointNotFoundException ex)
            {
                load_failed();
            }
        }

        private void btn_Update_Click(object sender, EventArgs e)
        {
            try
            {
                DataTable dataTable = (DataTable)dataGridView1.DataSource;
                load_factory();
                channel.UpdataTable(dataTable);
                ((ICommunicationObject)channel).Close();
                MessageBox.Show("수정되었습니다.");
            }
            catch(EndpointNotFoundException ex)
            {
                load_failed();
            }
        }

        private void btn_Remove_Click(object sender, EventArgs e)
        {
            try
            {
                load_factory();
                string temp = dataGridView1.SelectedRows[0].Cells[0].Value.ToString();
                channel.DeleteTable(temp);
                ((ICommunicationObject)channel).Close();

                load_factory();
                DataTable tempTable = channel.ISelectTable();
                dataGridView1.DataSource = tempTable;
                ((ICommunicationObject)channel).Close();
                MessageBox.Show("삭제되었습니다.");
            }
            catch(EndpointNotFoundException ex)
            {
                load_failed();
            }
            catch(ArgumentOutOfRangeException ex)
            {
                MessageBox.Show("삭제하기 원하시는 행을 클릭한 뒤 버튼을 눌러주세요.\n");
                ((ICommunicationObject)channel).Close();
            }
            
        }

        void load_factory()
        {
            factory = new ChannelFactory<IMySQL>();
            factory.Endpoint.Address = new EndpointAddress(address);
            factory.Endpoint.Binding = new NetTcpBinding();
            factory.Endpoint.Binding.ReceiveTimeout = new TimeSpan(24, 0, 0);
            factory.Endpoint.Binding.OpenTimeout = new TimeSpan(24, 0, 0);
            factory.Endpoint.Binding.CloseTimeout = new TimeSpan(24, 0, 0);
            factory.Endpoint.Binding.SendTimeout = new TimeSpan(24, 0, 0);
            factory.Endpoint.Contract.ContractType = typeof(IMySQL);
            channel = factory.CreateChannel();
        }

        void load_failed()
        {
            MessageBox.Show("연결실패");
        }
    }
}
