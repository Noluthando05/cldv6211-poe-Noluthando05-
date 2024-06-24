using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Data.SqlClient;

namespace KhumaloCraftReg_2.Pages.Products
{
    public class IndexModel : PageModel
    {
        public List<ProductInfo> listProducts =new List<ProductInfo>();

        public void OnGet()
        {
            try
            {
                string connectionString = "Data Source=NOLUTHANDO;Initial Catalog=MyProducts;Integrated Security=True;Trust Server Certificate=True";
				using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();
                    String sql = "SELECT * FROM MyProducts";
                    using (SqlCommand  command= new SqlCommand(sql, connection))
                    {
                        using (SqlDataReader reader = command.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                ProductInfo productInfo = new ProductInfo();
                                productInfo.id = "" + reader.GetInt32(0);
                                productInfo.price = "" + reader.GetInt32(1);
                                productInfo.product_name = reader.GetString(2);
                                productInfo.availability = reader.GetString(3);
                                productInfo.ratings = reader.GetString(4);
                                productInfo.category = reader.GetString(5);
                                productInfo.create_at = reader.GetDateTime(6).ToString();


                                listProducts.Add(productInfo);

                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Exeption:" + ex.ToString());
            }
           



        }

        }
    }
    public class ProductInfo
    {
        public String id;
        public String product_name;
        public String price;
        public String availability;
        public String ratings;
     public String category;
    public String create_at;
    }

