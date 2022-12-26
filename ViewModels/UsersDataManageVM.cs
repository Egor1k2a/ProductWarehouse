using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using ProductWarehouse.Extentions;
using ProductWarehouse.Views;
using ProductWarehouse.Models;
using System.Collections.ObjectModel;
using System.IO;
using System.Xml.Linq;

namespace ProductWarehouse.ViewModels
{
    public class UsersDataManageVM : BaseVM
    {
        public DataProducts DataProducts { get; set; }

        #region COMMAND TO REGISTRATION
        //регистрация клиентов

        public static Random rnd = new Random();

        public static string Login { get; set; }
        public static string Password { get; set; }
        public static string SecondPassword { get; set; }
        public static string Email { get; set; }
        public static string PhoneNumber { get; set; }

        private ActionCommand addNewUser;
        public ActionCommand AddNewUser
        {
            get
            {
                return addNewUser ?? new ActionCommand(obj =>
                {
                    Window wnd = obj as Window;
                    XDocument xdoc1 = XDocument.Load("Client.xml");
                    var loginClient = xdoc1.Element("ArrayOfClient")?.Elements("Client").FirstOrDefault(p => p.Element("Login")?.Value == Login);
                    XDocument xdoc2 = XDocument.Load("Employee.xml");
                    var loginEmployee = xdoc2.Element("ArrayOfEmployee")?.Elements("Employee").FirstOrDefault(p => p.Element("Login")?.Value == Login);
                    XDocument xdoc3 = XDocument.Load("Admin.xml");
                    var loginAdmin = xdoc3.Element("ArrayOfAdmin")?.Elements("Admin").FirstOrDefault(p => p.Element("Login")?.Value == Login);

                    string errorStr = "";
                    if(Login == null || Login.Length < 5 || Login.Replace(" ", "").Length == 0)
                    {
                        errorStr = "Слишком короткий логин!";
                        OpenErrorMessageWindow(errorStr);
                    }
                    else if(loginClient != null || loginEmployee != null || loginAdmin != null)
                    {
                        errorStr = "Данный логин уже существует!";
                        OpenErrorMessageWindow(errorStr);
                    }
                    else if(Password == null || Password.Length < 8 || Password.Replace(" ", "").Length == 0)
                    {
                        errorStr = "Слишком короткий пароль!";
                        OpenErrorMessageWindow(errorStr);
                    }
                    else if (SecondPassword != Password)
                    {
                        errorStr = "Пароли не совпадают!";
                        OpenErrorMessageWindow(errorStr);
                    }
                    else if (Email == null || Email.Length < 5 || !Email.Contains("@") || !Email.Contains("."))
                    {
                        errorStr = "Неверно введен Email!";
                        OpenErrorMessageWindow(errorStr);
                    }
                    else if (PhoneNumber == null || PhoneNumber.Length < 11 || (!PhoneNumber.StartsWith("+7") && !PhoneNumber.StartsWith("8")))
                    {
                        errorStr = "Неверно введен номер телефона!";
                        OpenErrorMessageWindow(errorStr);
                    }
                    else
                    {
                        ObservableCollection<Client> clients = new ObservableCollection<Client>();
                        Client client = new Client();
                        client.ID = rnd.Next(0, 1000);
                        client.Login = Login;
                        client.Password = Password;
                        client.Email = Email;
                        client.PhoneNumber = PhoneNumber;
                        clients.Add(client);

                        if (!File.Exists("Client.xml"))
                        {
                            DataProducts dataProducts = new DataProducts();
                            dataProducts.SaveFirstData(clients, "Client");
                        }

                        else
                        {
                            XDocument xdoc = XDocument.Load("Client.xml");
                            XElement root = xdoc.Element("ArrayOfClient");

                            if (root != null)
                            {
                                root.Add(new XElement("Client",
                                            new XElement("ID", rnd.Next(0, 1000)),
                                            new XElement("Login", Login),
                                            new XElement("Password", Password),
                                            new XElement("Email", Email),
                                            new XElement("PhoneNumber", PhoneNumber),
                                            new XElement("TypeOfUser", client.TypeOfUser)));
                                xdoc.Save("Client.xml");
                            }
                        }

                        SetNullValuesToPropertiesUser();
                        OpenInputWindowMetod();
                        wnd.Close();
                    }
                }
                    );
            }
        }

        #endregion

        #region COMMAND TO INPUT

        public static string ID { get; set; }
        private ActionCommand openUserInterface;
        public ActionCommand OpenUserInterface
        {
            get
            {
                return openUserInterface ?? new ActionCommand(obj =>
                {
                    Window wnd = obj as Window;
                    bool stop = false;

                    if (File.Exists("Client.xml"))
                    {
                        XDocument xdoc1 = XDocument.Load("Client.xml");
                        var client = xdoc1.Element("ArrayOfClient")?.Elements("Client").FirstOrDefault(p => p.Element("Login")?.Value == Login);
                        if (client != null)
                        {
                            stop = true;
                            if (client.Element("Password").Value == Password)
                            {
                                OpenUserInterfaceMetod("client");
                                ID = client.Element("ID").Value;
                                wnd.Close();
                                SetNullValuesToPropertiesUser();
                            }
                            else
                            {
                                OpenErrorMessageWindow("Введен неправильный логин или пароль!");
                            }
                        }
                        else
                        {
                            if(!File.Exists("Employee.xml") && !File.Exists("Admin.xml"))
                            {
                                OpenErrorMessageWindow("Введен неправильный логин или пароль!");
                            }
                        }
                    }

                    if (File.Exists("Employee.xml") && !stop)
                    {
                        XDocument xdoc2 = XDocument.Load("Employee.xml");
                        var employee = xdoc2.Element("ArrayOfEmployee")?.Elements("Employee").FirstOrDefault(p => p.Element("Login")?.Value == Login);
                        if (employee != null)
                        {
                            stop = true;
                            if (employee.Element("Password").Value == Password)
                            {
                                OpenUserInterfaceMetod("employee");
                                ID = employee.Element("ID").Value;
                                wnd.Close();
                                SetNullValuesToPropertiesUser();
                            }
                            else
                            {
                                OpenErrorMessageWindow("Введен неправильный логин или пароль!");
                            }
                        }
                        else
                        {
                            if (!File.Exists("Admin.xml"))
                            {
                                OpenErrorMessageWindow("Введен неправильный логин или пароль!");
                            }
                        }
                    }

                    if (File.Exists("Admin.xml") && !stop)
                    {
                        XDocument xdoc3 = XDocument.Load("Admin.xml");
                        var admin = xdoc3.Element("ArrayOfAdmin")?.Elements("Admin").FirstOrDefault(p => p.Element("Login")?.Value == Login);
                        if (admin != null)
                        {
                            if (admin.Element("Password").Value == Password)
                            {
                                OpenUserInterfaceMetod("admin");
                                ID = admin.Element("ID").Value;
                                wnd.Close();
                                SetNullValuesToPropertiesUser();
                            }
                            else
                            {
                                OpenErrorMessageWindow("Введен неправильный логин или пароль!");
                            }
                        }
                        else
                        {
                            OpenErrorMessageWindow("Введен неправильный логин или пароль!");
                        }
                    }
                }
                    );
            }
        }

        #endregion

        #region COMMAND TO OPEN WINDOW

        private ActionCommand openInputWnd;
        public ActionCommand OpenInputWnd
        {
            get
            {
                return openInputWnd ?? new ActionCommand(obj =>
                {
                    Window wnd = obj as Window;
                    OpenInputWindowMetod();
                    wnd.Close();
                }
                    );
            }
        }

        private ActionCommand openRegistrationWnd;
        public ActionCommand OpenRegistrationWnd
        {
            get
            {
                return openRegistrationWnd ?? new ActionCommand(obj =>
                {
                    Window wnd = obj as Window;
                    OpenRegistrationWindowMetod();
                    wnd.Close();
                }
                    );
            }
        }

        #endregion

        #region METOD TO OPEN WINDOW
        //методы для открытия окон

        private void OpenInputWindowMetod()
        {
            InputWindow inputWindow = new InputWindow();
            inputWindow.Show();
        }

        private void OpenRegistrationWindowMetod()
        {
            RegistrationWindow registrationWindow = new RegistrationWindow();
            registrationWindow.Show();
        }

        private void OpenProductsWindowMetod()
        {
            ProductsWindow productsWindow = new ProductsWindow();
            productsWindow.Show();
        }

        private void OpenClientInterfaceMetod()
        {
            ClientInterface clientInterface = new ClientInterface();
            clientInterface.Show();
        }

        private void OpenAdminInterfaceMetod()
        {
            AdminInterface adminInterface = new AdminInterface();
            adminInterface.Show();
        }

        public void OpenErrorMessageWindow(string str)
        {
            ErrorMessageWindow errorMessageWindow = new ErrorMessageWindow(str);
            errorMessageWindow.ShowDialog();
        }

        private void OpenUserInterfaceMetod(string typeOfUser)
        {
            if(typeOfUser == "admin")
            {
                OpenAdminInterfaceMetod();
            }
            else if (typeOfUser == "employee")
            {
                OpenProductsWindowMetod();
            }
            else if(typeOfUser == "client")
            {
                OpenClientInterfaceMetod();
            }
            else
            {
                OpenErrorMessageWindow("Возникла ошибка!");
            }
        }

        #endregion

        //Обнуление переменных
        private void SetNullValuesToPropertiesUser()
        {
            Login = null;
            Password = null;
            SecondPassword = null;
            Email = null;
            PhoneNumber = null;
        }

    }
}
