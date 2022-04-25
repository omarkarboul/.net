using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace PS.Domain
{
  public  class Provider : Concept
    {

        //[Key] ken badalna el esm
        public int ProviderId {get; set;}

        public string UserName {get; set;}
        


        //public string Password {get; set;}
        private string password;


        [DataType(DataType.Password)]
        [Required]
        [MinLength(8, ErrorMessage ="minimin 8 characters")]
        public string Password
        {
            get { return password; }
            set
            {
                if (value.Length < 20 && value.Length > 5)
                {
                    password = value;
                }
                else Console.WriteLine("enter a valid password");
            }
        }
        private string confirmPassword;

        [DataType(DataType.Password)]
        [Required]
        [MinLength(8, ErrorMessage = "minimin 8 characters")]
        [NotMapped]
        [Compare("Password",ErrorMessage ="password must match")]
        public string ConfirmPassword
        {
            get { return confirmPassword; }
            set
            {
                if (value == password)
                {
                    confirmPassword = value;
                }
                else Console.WriteLine("re-enter a valid password");
            }
        }


        [EmailAddress]
        [Required]
        public string Email {get; set;}

        public DateTime DateCreated {get; set;}

        public bool IsApproved {get; set;}

        public virtual List<Product> Products {get; set;}

        public static void SetIsApproved(Provider p)
        {
            if (p.password == p.confirmPassword)
                p.IsApproved = true;
            else
                p.IsApproved = false;
        }
        public static void SetIsApproved(string password, string confirmation, bool isApproved)
        {
            isApproved = (password == confirmation);
        }


        //public bool login(String user , String password)
        //{
        //    if (user == UserName && password == Password)
        //    {
        //        return true;
        //    }
        //    else
        //        return false;
        //}

        //public bool login(String user, String password, String email)
        //{
        //    return user == UserName && password == Password && email == Email;
        //}

        public bool login(String user, String password, String email=null)
        {
            if (email == null)
            {
                return user == UserName && password == Password;
            }
            else
                return user == UserName && password == Password && email == Email;

        }

        public override void getDetails()
        {
            Console.WriteLine("nom :"+UserName);
            for (int i = 0; i < Products.Count; i++)
            {
                Console.WriteLine(Products[i]);
            }
        }

        public void GetProducts(String filterType, String filterValue)
        {
            switch (filterType)
            {
                case "Name":
                    for (int i = 0; i < Products.Count; i++) {
                        if(Products[i].Name.Equals(filterValue))
                            Console.WriteLine(Products[i]);
                    } 
                    break;

                case "DateProd":
                    foreach(Product p in Products)
                        if(p.DateProd == DateTime.Parse(filterValue))
                            Console.WriteLine(p);
                    break;
                case "Price":
                    foreach (Product p in Products)
                        if(p.Price == double.Parse(filterValue))
                            Console.WriteLine(p);
                    break;

            }
        }
    }
}