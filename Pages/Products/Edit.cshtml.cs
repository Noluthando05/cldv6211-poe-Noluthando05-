using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Data.SqlClient;

namespace KhumaloCraftReg_2.Pages.Products
{
    public class EditModel : PageModel
    {
        public ProductInfo productInfo = new ProductInfo();
        public string errorMessage = "";
        public string successMessage = "";
		private string connectionString;

		public void OnGet()
        {
            String id = Request.Query["id"];

            try
            {
                String ConnectionString = "Data Source=NOLUTHANDO;Initial Catalog=MyProducts;Integrated Security=True;Encrypt=True;Trust Server Certificate=True";
                using (SqlConnection connection = new SqlConnection(connectionString)) 
                
                
                {
                connection.Open();
                    String sql = "SELECT * FROM products where id = @id";
                    using (SqlCommand command = new SqlCommand(sql, connection))
                    
                    { 
                    command.Parameters.AddWithValue("id", id);  
                        using (SqlDataReader reader = command.ExecuteReader())
                        { 
                        if (reader.Read()) 
                             
                            { 
                            productInfo.id = ""+reader.GetInt32(0);
                                productInfo.price = "" + reader.GetInt32(1);
                                productInfo.product_name = reader.GetString(2);
                                productInfo.ratings = reader.GetString(3);
                                productInfo.availability = reader.GetString(4);
                                productInfo.category = reader.GetString(5);
                            
                            }
                        
                        
                        }
                    
                    }
                
                
                }
                
              
               

            }
            catch (Exception ex)
            {
                errorMessage = ex.Message;
            }

        }

		public string? GetStringValues()
		{
			return Request.Form["price"];
		}

		public void OnPost(string? stringValues)
        {
			productInfo.id = Request.Form["id"];
            productInfo.product_name = Request.Form["product name"];
            productInfo.price = stringValues;
            productInfo.availability = Request.Form["availibility"];
            productInfo.ratings = Request.Form["ratings"];
            productInfo.category = Request.Form["category"];
            
            if( productInfo.id.Length == 0 || productInfo.product_name.Length == 0|| productInfo.price.Length == 0|| productInfo.availability.Length == 0 ||
                productInfo.ratings.Length == 0 || productInfo.category.Length == 0)
            {
                errorMessage = "All fields are required";
                return;
            }
            try
            {
                String connectionString = "Data Source=NOLUTHANDO;Initial Catalog=KhumaloProducts;Integrated Security=True;Encrypt=True;Trust Server Certificate=True";
                using (SqlConnection connection = new SqlConnection(connectionString))
                
                
                
                { 
                connection.Open();
                    String sql = "Update clients" +
                        "Set product name = @product name,price=@price, category=@category ,availibility=@availibility ,ratings=@ratings" +
                    "WHERE id=@id";
                    

                    using (SqlCommand command = new SqlCommand(sql, connection)) 
                    
                    {
						command.Parameters.AddWithValue("@product name", productInfo.product_name);
						command.Parameters.AddWithValue("@price", productInfo.price);
						command.Parameters.AddWithValue(@"category", productInfo.category);
						command.Parameters.AddWithValue("@availibility", productInfo.availability);
						command.Parameters.AddWithValue("@ratings", productInfo.ratings);
                        command.Parameters.AddWithValue("@id", productInfo.id);
						command.ExecuteNonQuery();


					}
                }  
                




            }
            catch(Exception ex)
            
            { 
            errorMessage=ex.Message;
                return;
            }

            Response.Redirect("/Products/Index");
        }
    }
}
