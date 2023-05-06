using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Data.SqlClient;

namespace Crud_by_Me.Pages.Clients
{
    public class IndexModel : PageModel
    {
        public List<ClientInfo> ListClients = new List<ClientInfo>();
        public void OnGet()
        {
            
            try
            {

                string connectionstring = "Data Source=.;Initial Catalog=Store;User ID=sa;Password=aptech";

                using (SqlConnection conn = new SqlConnection(connectionstring))
                {
                    conn.Open();

                    String sql = "Select * from clients";

                    using (SqlCommand cmd = new SqlCommand(sql, conn))
                    {
                        using (SqlDataReader reader = cmd.ExecuteReader())
                        {
                           while(reader.Read())
                            {
                                ClientInfo clientinfo = new ClientInfo();
                                clientinfo.id = "" + reader.GetInt32(0);
                                clientinfo.Name = reader.GetString(1);
                                clientinfo.Email = reader.GetString(2);
                                clientinfo.Phone = reader.GetString(3);
                                clientinfo.Address = reader.GetString(4);
                                clientinfo.created_at = reader.GetDateTime(5).ToString();

                                ListClients.Add(clientinfo);

                            }
                        }

                    }


                        conn.Close();


                }

            }
            catch (Exception ex)
            {
                Console.WriteLine("Error:" +ex);
            }
        }

       
    }
    public class ClientInfo
    {

        public string id;
        public string Name;
        public string Email;
        public string Phone;
        public string Address;
        public string created_at;
    }
}
