using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ProductWarehouse.Models;
using ProductWarehouse.Views;
using ProductWarehouse.Extentions;
using System.Windows.Input;
using System.Collections.ObjectModel;
using System.Windows;
using System.IO;
using System.Xml.Serialization;
using System.Xml.Linq;
using System.Windows.Controls;

namespace ProductWarehouse.ViewModels
{
    public class DataManage : BaseVM
    {
        public DataProducts DataProducts { get; set; }
        public UsersDataManageVM UsersDataManageVM { get; set; }

        #region SELECTED EMPLOYEE

        //выбранный сотрудник
        private static Employee selectedEmployee = new Employee();
        public static Employee SelectedEmployee
        {
            get { return selectedEmployee; }
            set { selectedEmployee = value; }
        }

        #endregion

        #region SELECTED PRODUCT

        //выбранный продукт
        public TabItem SelectedTabItem { get; set; }

        //выбранный молочный продукт
        private static Dairy selectedDairy = new Dairy();
        public static Dairy SelectedDairy
        {
            get { return selectedDairy; }
            set { selectedDairy = value; }
        }

        //выбранный рыбный продукт
        private static Fish selectedFish = new Fish();
        public static Fish SelectedFish
        {
            get { return selectedFish; }
            set { selectedFish = value; }
        }

        //выбранный фрукт
        private static Fruit selectedFruit = new Fruit();
        public static Fruit SelectedFruit
        {
            get { return selectedFruit; }
            set { selectedFruit = value; }
        }

        //выбранный мясной продукт
        private static Meat selectedMeat = new Meat();
        public static Meat SelectedMeat
        {
            get { return selectedMeat; }
            set { selectedMeat = value; }
        }

        //выбранный овощ
        private static Vegetables selectedVegetables = new Vegetables();
        public static Vegetables SelectedVegetables
        {
            get { return selectedVegetables; }
            set { selectedVegetables = value; }
        }

        //выбранный зарезервированный продукт
        private static ReservationProduct selectedReservationProduct = new ReservationProduct();
        public static ReservationProduct SelectedReservationProduct
        {
            get { return selectedReservationProduct; }
            set { selectedReservationProduct = value; }
        }

        #endregion

        #region COMMAND GET PRODUCTS

        //Выгрузить продукты в окно
        public void LoadInfoFromDB<T>(ObservableCollection<T> collection, string FileName)
        {
            FileName = FileName + ".xml";
            if (!File.Exists(FileName))
            {
                return;
            }
            XmlSerializer serializer = new XmlSerializer(typeof(ObservableCollection<T>));

            using (Stream reader = new FileStream(FileName, FileMode.Open))
            {
                if (reader.Length == 0)
                {
                    return;
                }
                collection.AddRange((ObservableCollection<T>)serializer.Deserialize(reader));
            }
        }

        //Выгрузить зарезервированные продукты
        private ObservableCollection<ReservationProduct> reservationProductsAll;
        private ObservableCollection<ReservationProduct> reservationProductsNotAcknowledge;
        public ObservableCollection<ReservationProduct> ReservationProductsAll
        {
            get
            {
                reservationProductsAll = null;
                reservationProductsNotAcknowledge = null;
                if (reservationProductsAll == null)
                {
                    reservationProductsAll = new ObservableCollection<ReservationProduct>();
                    LoadInfoFromDB(reservationProductsAll, "ReservationProduct");
                    reservationProductsNotAcknowledge = new ObservableCollection<ReservationProduct>();
                    for (int i = 0; i < reservationProductsAll.Count; i++)
                    {
                        if(reservationProductsAll[i].Condition == "В обработке")
                        {
                            reservationProductsNotAcknowledge.Add(reservationProductsAll[i]);
                        }
                    }
                }
                return reservationProductsNotAcknowledge;
            }
            set
            {
                reservationProductsAll = value;
                OnPropertyChanged("ReservationProductsAll");
            }
        }

        //Выгрузить зарезервированные продукты по ID клиента
        private ObservableCollection<ReservationProduct> reservationProductsID;
        public ObservableCollection<ReservationProduct> ReservationProductsID
        {
            get
            {
                reservationProductsAll = null;
                reservationProductsID = null;
                if (reservationProductsAll == null)
                {
                    reservationProductsAll = new ObservableCollection<ReservationProduct>();
                    LoadInfoFromDB(reservationProductsAll, "ReservationProduct");
                    reservationProductsID = new ObservableCollection<ReservationProduct>();
                    for(int i = 0; i < reservationProductsAll.Count; i++)
                    {
                        if(reservationProductsAll[i].IDOfClient == UsersDataManageVM.ID)
                        {
                            reservationProductsID.Add(reservationProductsAll[i]);
                        }
                    }
                }
                return reservationProductsID;
            }
            set
            {
                reservationProductsID = value;
                OnPropertyChanged("ReservationProductsID");
            }
        }

        //Выгрузить молочные продукты
        private ObservableCollection<Dairy> dairies;
        public ObservableCollection<Dairy> Dairies
        {
            get
            {
                dairies = null;
                if (dairies == null)
                {
                    dairies = new ObservableCollection<Dairy>();
                    LoadInfoFromDB(dairies, "Dairy");
                }
                return dairies;
            }
            set
            {
                dairies = value;
                OnPropertyChanged("Dairies");
            }
        }

        //Выгрузить рыбные продукты
        private ObservableCollection<Fish> fishes;
        public ObservableCollection<Fish> Fishes
        {
            get
            {
                fishes = null;
                if (fishes == null)
                {
                    fishes = new ObservableCollection<Fish>();
                    LoadInfoFromDB(fishes, "Fish");
                }
                return fishes;
            }
            set
            {
                fishes = value;
                OnPropertyChanged("Fishes");
            }
        }

        //Выгрузить фрукты
        private ObservableCollection<Fruit> fruit;
        public ObservableCollection<Fruit> Fruit
        {
            get
            {
                fruit = null;
                if (fruit == null)
                {
                    fruit = new ObservableCollection<Fruit>();
                    LoadInfoFromDB(fruit, "Fruit");
                }
                return fruit;
            }
            set
            {
                fruit = value;
                OnPropertyChanged("Fruit");
            }
        }

        //Выгрузить мясные продукты
        private ObservableCollection<Meat> meat;
        public ObservableCollection<Meat> Meat
        {
            get
            {
                meat = null;
                if (meat == null)
                {
                    meat = new ObservableCollection<Meat>();
                    LoadInfoFromDB(meat, "Meat");
                }
                return meat;
            }
            set
            {
                meat = value;
                OnPropertyChanged("Meat");
            }
        }

        //Выгрузить овощи
        private ObservableCollection<Vegetables> vegetables;
        public ObservableCollection<Vegetables> Vegetables
        {
            get
            {
                vegetables = null;
                if (vegetables == null)
                {
                    vegetables = new ObservableCollection<Vegetables>();
                    LoadInfoFromDB(vegetables, "Vegetables");
                }
                return vegetables;
            }
            set
            {
                vegetables = value;
                OnPropertyChanged("Vegetables");
            }
        }

        #endregion

        #region COMMAND GET LOG

        private ObservableCollection<Logs> logs;
        public ObservableCollection<Logs> Logs
        {
            get
            {
                logs = null;
                if (logs == null)
                {
                    logs = new ObservableCollection<Logs>();
                    LoadInfoFromDB(logs, "Logs");
                }
                return logs;
            }
            set
            {
                logs = value;
                OnPropertyChanged("Logs");
            }
        }

        #endregion

        #region COMMAND GET USERS

        private ObservableCollection<Employee> employee;
        public ObservableCollection<Employee> Employee
        {
            get
            {
                employee = null;
                if (employee == null)
                {
                    employee = new ObservableCollection<Employee>();
                    LoadInfoFromDB(employee, "Employee");
                }
                return employee;
            }
            set
            {
                employee = value;
                OnPropertyChanged("Employee");
            }
        }

        #endregion

        #region METOD TO ADD LOG

        private void AddLog(string iDOfUserLog, string operation, string nameOfProductLog, string editing)
        {
            if (operation != null && nameOfProductLog != null && editing != null)
            {
                ObservableCollection<Logs> logs = new ObservableCollection<Logs>();
                Logs log = new Logs();
                log.IDOfUserLog = iDOfUserLog;
                log.Operation = operation;
                log.NameOfProductLog = nameOfProductLog;
                log.Editing = editing;
                log.TimeToEdit = DateTime.Now.ToString();
                logs.Add(log);

                if (!File.Exists("Logs.xml"))
                {
                    DataProducts dataProducts = new DataProducts();
                    dataProducts.SaveFirstData(logs, "Logs");
                }

                else
                {
                    XDocument xdoc = XDocument.Load("Logs.xml");
                    XElement root = xdoc.Element("ArrayOfLogs");

                    if (root != null)
                    {
                        // добавляем новый элемент
                        root.Add(new XElement("Logs",
                                    new XElement("IDOfUserLog", UsersDataManageVM.ID),
                                    new XElement("Operation", operation),
                                    new XElement("NameOfProductLog", nameOfProductLog),
                                    new XElement("Editing", editing),
                                    new XElement("TimeToEdit", DateTime.Now.ToString())));

                        xdoc.Save("Logs.xml");
                    }
                }
            }
        }

        #endregion

        #region COMMAND TO DELETE

        //удаление продукта
        private ActionCommand deleteProductCommand;
        public ActionCommand DeleteProductCommand
        {
            get
            {
                return deleteProductCommand ?? new ActionCommand(obj =>
                {
                    XDocument xdocemployee = XDocument.Load("Employee.xml");
                    var rootemployee = xdocemployee.Element("ArrayOfEmployee")?.Elements("Employee").FirstOrDefault(p => p.Element("ID")?.Value == UsersDataManageVM.ID);
                    if (rootemployee != null)
                    {
                        var toAdd = rootemployee.Element("ToDelete");
                        if (toAdd.Value == "True")
                        {
                            string operation = null, nameOfProductLog = null, editing = null;

                            //если выбран молочный продукт
                            if (SelectedTabItem.Name == "DairyTab" && SelectedDairy != null)
                            {
                                XDocument xdoc = XDocument.Load("Dairy.xml");
                                XElement root = xdoc.Element("ArrayOfDairy");
                                if (root != null)
                                {
                                    var deleteDairy = root.Elements("Dairy").FirstOrDefault(p => p.Element("ID")?.Value == SelectedDairy.ID.ToString());
                                    if (deleteDairy != null)
                                    {
                                        deleteDairy.Remove();
                                        xdoc.Save("Dairy.xml");
                                        operation = "Удаление";
                                        nameOfProductLog = SelectedDairy.NameOfProduct;
                                        editing = "ID, Наименование, Цена за кг, Всего кг, Кол-во упаковок, Цена за упаковку";
                                    }
                                }
                                UpdateAllDataView();
                            }

                            //если выбран рыбный продукт
                            if (SelectedTabItem.Name == "FishTab" && SelectedFish != null)
                            {
                                XDocument xdoc = XDocument.Load("Fish.xml");
                                XElement root = xdoc.Element("ArrayOfFish");
                                if (root != null)
                                {
                                    var deleteFish = root.Elements("Fish").FirstOrDefault(p => p.Element("ID")?.Value == SelectedFish.ID.ToString());
                                    if (deleteFish != null)
                                    {
                                        deleteFish.Remove();
                                        xdoc.Save("Fish.xml");
                                        operation = "Удаление";
                                        nameOfProductLog = SelectedFish.NameOfProduct;
                                        editing = @"ID, Наименование, Цена за кг, Всего кг, Тип рыбы, Живая\Неживая";
                                    }
                                }
                                UpdateAllDataView();
                            }

                            //если выбран фрукт
                            if (SelectedTabItem.Name == "FruitTab" && SelectedFruit != null)
                            {
                                XDocument xdoc = XDocument.Load("Fruit.xml");
                                XElement root = xdoc.Element("ArrayOfFruit");
                                if (root != null)
                                {
                                    var deleteFruit = root.Elements("Fruit").FirstOrDefault(p => p.Element("ID")?.Value == SelectedFruit.ID.ToString());
                                    if (deleteFruit != null)
                                    {
                                        deleteFruit.Remove();
                                        xdoc.Save("Fruit.xml");
                                        operation = "Удаление";
                                        nameOfProductLog = SelectedFruit.NameOfProduct;
                                        editing = "ID, Наименование, Цена за кг, Всего кг, Месяц сбора, День сбора";
                                    }
                                }
                                UpdateAllDataView();
                            }

                            //если выбран мясной продукт
                            if (SelectedTabItem.Name == "MeatTab" && SelectedMeat != null)
                            {
                                XDocument xdoc = XDocument.Load("Meat.xml");
                                XElement root = xdoc.Element("ArrayOfMeat");
                                if (root != null)
                                {
                                    var deleteMeat = root.Elements("Meat").FirstOrDefault(p => p.Element("ID")?.Value == SelectedMeat.ID.ToString());
                                    if (deleteMeat != null)
                                    {
                                        deleteMeat.Remove();
                                        xdoc.Save("Meat.xml");
                                        operation = "Удаление";
                                        nameOfProductLog = SelectedMeat.NameOfProduct;
                                        editing = "ID, Наименование, Цена за кг, Всего кг, Тип мяса";
                                    }
                                }
                                UpdateAllDataView();
                            }

                            //если выбран овощ
                            if (SelectedTabItem.Name == "VegetablesTab" && SelectedVegetables != null)
                            {
                                XDocument xdoc = XDocument.Load("Vegetables.xml");
                                XElement root = xdoc.Element("ArrayOfVegetables");
                                if (root != null)
                                {
                                    var deleteVegetables = root.Elements("Vegetables").FirstOrDefault(p => p.Element("ID")?.Value == SelectedVegetables.ID.ToString());
                                    if (deleteVegetables != null)
                                    {
                                        deleteVegetables.Remove();
                                        xdoc.Save("Vegetables.xml");
                                        operation = "Удаление";
                                        nameOfProductLog = SelectedVegetables.NameOfProduct;
                                        editing = "ID, Наименование, Цена за кг, Всего кг, Месяц сбора, День сбора";
                                    }
                                }
                                UpdateAllDataView();
                            }

                            AddLog(UsersDataManageVM.ID, operation, nameOfProductLog, editing);

                            SetNullValuesToProperties();
                        }
                        else
                        {
                            OpenErrorMessageWindow("У вас недостаточно прав!");
                        }
                    }
                });
            }
        }

        #endregion

        #region COMMAND TO ADD

        private static Random rnd = new Random();

        public static string NameOfProduct { get; set; }
        public static float PricePerKilogram { get; set; }
        public static int TotalKilogram { get; set; }
        public static int NumberOfPackages { get; set; }
        public static int PricePerPack { get; set; }
        public static string FishCondition { get; set; }
        public static string FishType { get; set; }
        public static int CollectionDay { get; set; }
        public static int CollectionMonth { get; set; }
        public static string MeatType { get; set; }

        //добавить молочный продукт
        private ActionCommand addNewDairy;
        public ActionCommand AddNewDairy
        {
            get
            {
                return addNewDairy ?? new ActionCommand(obj =>
                    {
                        string operation = "Создание", nameOfProductLog = null, editing = null;
                        Window wnd = obj as Window;
                        ObservableCollection<Dairy> dairies = new ObservableCollection<Dairy>();
                        Dairy dairy = new Dairy();
                        dairy.ID = rnd.Next(0, 1000);
                        dairy.NameOfProduct = NameOfProduct;
                        dairy.PricePerKilogram = PricePerKilogram;
                        dairy.TotalKilogram = TotalKilogram;
                        dairy.NumberOfPackages = NumberOfPackages;
                        dairy.PricePerPack = PricePerPack;
                        dairies.Add(dairy);

                        nameOfProductLog = NameOfProduct;
                        editing = "ID, Наименование, Цена за кг, Всего кг, Кол-во упаковок, Цена за упаковку";

                        if (!File.Exists("Dairy.xml"))
                        {
                            DataProducts dataProducts = new DataProducts();
                            dataProducts.SaveFirstData(dairies, "Dairy");
                        }

                        else
                        {
                            XDocument xdoc = XDocument.Load("Dairy.xml");
                            XElement root = xdoc.Element("ArrayOfDairy");

                            if (root != null)
                            {
                                // добавляем новый элемент
                                root.Add(new XElement("Dairy",
                                            new XElement("ID", rnd.Next(0, 1000)),
                                            new XElement("NameOfProduct", NameOfProduct),
                                            new XElement("PricePerKilogram", PricePerKilogram),
                                            new XElement("TotalKilogram", TotalKilogram),
                                            new XElement("NumberOfPackages", NumberOfPackages),
                                            new XElement("PricePerPack", PricePerPack)));

                                xdoc.Save("Dairy.xml");
                            }
                        }

                        AddLog(UsersDataManageVM.ID, operation, nameOfProductLog, editing);
                        ShowMessageToUser();
                        UpdateAllDataView();
                        SetNullValuesToProperties();
                        wnd.Close();
                    }
                    );
            }
        }

        //добавить рыбный продукт
        private ActionCommand addNewFish;
        public ActionCommand AddNewFish
        {
            get
            {
                return addNewFish ?? new ActionCommand(obj =>
                {
                    string operation = "Создание", nameOfProductLog = null, editing = null;
                    Window wnd = obj as Window;
                    ObservableCollection<Fish> fishes = new ObservableCollection<Fish>();
                    Fish fish = new Fish();
                    fish.ID = rnd.Next(0, 1000);
                    fish.NameOfProduct = NameOfProduct;
                    fish.PricePerKilogram = PricePerKilogram;
                    fish.TotalKilogram = TotalKilogram;
                    fish.FishCondition = FishCondition;
                    fish.FishType = FishType;
                    fishes.Add(fish);

                    nameOfProductLog = NameOfProduct;
                    editing = @"ID, Наименование, Цена за кг, Всего кг, Тип рыбы, Живая\Неживая";

                    if (!File.Exists("Fish.xml"))
                    {
                        DataProducts dataProducts = new DataProducts();
                        dataProducts.SaveFirstData(fishes, "Fish");
                    }

                    else
                    {
                        XDocument xdoc = XDocument.Load("Fish.xml");
                        XElement root = xdoc.Element("ArrayOfFish");

                        if (root != null)
                        {
                            // добавляем новый элемент
                            root.Add(new XElement("Fish",
                                        new XElement("ID", rnd.Next(0, 1000)),
                                        new XElement("NameOfProduct", NameOfProduct),
                                        new XElement("PricePerKilogram", PricePerKilogram),
                                        new XElement("TotalKilogram", TotalKilogram),
                                        new XElement("FishCondition", FishCondition),
                                        new XElement("FishType", FishType)));

                            xdoc.Save("Fish.xml");
                        }
                    }

                    AddLog(UsersDataManageVM.ID, operation, nameOfProductLog, editing);
                    ShowMessageToUser();
                    UpdateAllDataView();
                    SetNullValuesToProperties();
                    wnd.Close();
                }
                    );
            }
        }

        //добавить фрукт
        private ActionCommand addNewFruit;
        public ActionCommand AddNewFruit
        {
            get
            {
                return addNewFruit ?? new ActionCommand(obj =>
                {
                    string operation = "Создание", nameOfProductLog = null, editing = null;
                    Window wnd = obj as Window;
                    ObservableCollection<Fruit> fruits = new ObservableCollection<Fruit>();
                    Fruit fruit = new Fruit();
                    fruit.ID = rnd.Next(0, 1000);
                    fruit.NameOfProduct = NameOfProduct;
                    fruit.PricePerKilogram = PricePerKilogram;
                    fruit.TotalKilogram = TotalKilogram;
                    fruit.CollectionDay = CollectionDay;
                    fruit.CollectionMonth = CollectionMonth;
                    fruits.Add(fruit);

                    nameOfProductLog = NameOfProduct;
                    editing = "ID, Наименование, Цена за кг, Всего кг, Месяц сбора, День сбора";

                    if (!File.Exists("Fruit.xml"))
                    {
                        DataProducts dataProducts = new DataProducts();
                        dataProducts.SaveFirstData(fruits, "Fruit");
                    }

                    else
                    {
                        XDocument xdoc = XDocument.Load("Fruit.xml");
                        XElement root = xdoc.Element("ArrayOfFruit");

                        if (root != null)
                        {
                            // добавляем новый элемент
                            root.Add(new XElement("Fruit",
                                        new XElement("ID", rnd.Next(0, 1000)),
                                        new XElement("NameOfProduct", NameOfProduct),
                                        new XElement("PricePerKilogram", PricePerKilogram),
                                        new XElement("TotalKilogram", TotalKilogram),
                                        new XElement("CollectionDay", CollectionDay),
                                        new XElement("CollectionMonth", CollectionMonth)));

                            xdoc.Save("Fruit.xml");
                        }
                    }

                    AddLog(UsersDataManageVM.ID, operation, nameOfProductLog, editing);
                    ShowMessageToUser();
                    UpdateAllDataView();
                    SetNullValuesToProperties();
                    wnd.Close();
                }
                    );
            }
        }

        //добавить мясной продукт
        private ActionCommand addNewMeat;
        public ActionCommand AddNewMeat
        {
            get
            {
                return addNewMeat ?? new ActionCommand(obj =>
                {
                    string operation = "Создание", nameOfProductLog = null, editing = null;
                    Window wnd = obj as Window;
                    ObservableCollection<Meat> meats = new ObservableCollection<Meat>();
                    Meat meat = new Meat();
                    meat.ID = rnd.Next(0, 1000);
                    meat.NameOfProduct = NameOfProduct;
                    meat.PricePerKilogram = PricePerKilogram;
                    meat.TotalKilogram = TotalKilogram;
                    meat.MeatType = MeatType;
                    meats.Add(meat);

                    nameOfProductLog = NameOfProduct;
                    editing = "ID, Наименование, Цена за кг, Всего кг, Тип мяса";

                    if (!File.Exists("Meat.xml"))
                    {
                        DataProducts dataProducts = new DataProducts();
                        dataProducts.SaveFirstData(meats, "Meat");
                    }

                    else
                    {
                        XDocument xdoc = XDocument.Load("Meat.xml");
                        XElement root = xdoc.Element("ArrayOfMeat");

                        if (root != null)
                        {
                            // добавляем новый элемент
                            root.Add(new XElement("Meat",
                                        new XElement("ID", rnd.Next(0, 1000)),
                                        new XElement("NameOfProduct", NameOfProduct),
                                        new XElement("PricePerKilogram", PricePerKilogram),
                                        new XElement("TotalKilogram", TotalKilogram),
                                        new XElement("MeatType", MeatType)));

                            xdoc.Save("Meat.xml");
                        }
                    }

                    AddLog(UsersDataManageVM.ID, operation, nameOfProductLog, editing);
                    ShowMessageToUser();
                    UpdateAllDataView();
                    SetNullValuesToProperties();
                    wnd.Close();
                }
                    );
            }
        }

        //добавить овощ
        private ActionCommand addNewVegetable;
        public ActionCommand AddNewVegetable
        {
            get
            {
                return addNewVegetable ?? new ActionCommand(obj =>
                {
                    string operation = "Создание", nameOfProductLog = null, editing = null;
                    Window wnd = obj as Window;
                    ObservableCollection<Vegetables> vegetables = new ObservableCollection<Vegetables>();
                    Vegetables vegetable = new Vegetables();
                    vegetable.ID = rnd.Next(0, 1000);
                    vegetable.NameOfProduct = NameOfProduct;
                    vegetable.PricePerKilogram = PricePerKilogram;
                    vegetable.TotalKilogram = TotalKilogram;
                    vegetable.CollectionDay = CollectionDay;
                    vegetable.CollectionMonth = CollectionMonth;
                    vegetables.Add(vegetable);

                    nameOfProductLog = NameOfProduct;
                    editing = "ID, Наименование, Цена за кг, Всего кг, Месяц сбора, День сбора";

                    if (!File.Exists("Vegetables.xml"))
                    {
                        DataProducts dataProducts = new DataProducts();
                        dataProducts.SaveFirstData(vegetables, "Vegetables");
                    }

                    else
                    {
                        XDocument xdoc = XDocument.Load("Vegetables.xml");
                        XElement root = xdoc.Element("ArrayOfVegetables");

                        if (root != null)
                        {
                            // добавляем новый элемент
                            root.Add(new XElement("Vegetables",
                                        new XElement("ID", rnd.Next(0, 1000)),
                                        new XElement("NameOfProduct", NameOfProduct),
                                        new XElement("PricePerKilogram", PricePerKilogram),
                                        new XElement("TotalKilogram", TotalKilogram),
                                        new XElement("CollectionDay", CollectionDay),
                                        new XElement("CollectionMonth", CollectionMonth)));

                            xdoc.Save("Vegetables.xml");
                        }
                    }

                    AddLog(UsersDataManageVM.ID, operation, nameOfProductLog, editing);
                    ShowMessageToUser();
                    UpdateAllDataView();
                    SetNullValuesToProperties();
                    wnd.Close();
                }
                    );
            }
        }

        #endregion

        #region COMMAND TO EDIT

        //изменить выбранный молочный продукт
        private ActionCommand editDairy;
        public ActionCommand EditDairy
        {
            get
            {
                return editDairy ?? new ActionCommand(obj =>
                {
                    string operation = "Редактирование", nameOfProductLog = null, editing = null;
                    Window wnd = obj as Window;
                    nameOfProductLog = SelectedDairy.NameOfProduct;
                    if (SelectedDairy != null)
                    {
                        XDocument xdoc = XDocument.Load("Dairy.xml");
                        var nowEditDairy = xdoc.Element("ArrayOfDairy")?.Elements("Dairy").FirstOrDefault(p => p.Element("ID")?.Value == SelectedDairy.ID.ToString());
                        
                        if(nowEditDairy != null)
                        {
                            var nameOfProduct = nowEditDairy.Element("NameOfProduct");
                            if (nameOfProduct != null)
                            {
                                if(nameOfProduct.Value != SelectedDairy.NameOfProduct)
                                {
                                    editing += "Наименование, ";
                                }
                                nameOfProduct.Value = SelectedDairy.NameOfProduct;
                            }
                            var pricePerKilogram = nowEditDairy.Element("PricePerKilogram");
                            if (pricePerKilogram != null)
                            {
                                if (pricePerKilogram.Value != SelectedDairy.PricePerKilogram.ToString())
                                {
                                    editing += "Цена за кг, ";
                                }
                                pricePerKilogram.Value = SelectedDairy.PricePerKilogram.ToString();
                            }
                            var totalKilogram = nowEditDairy.Element("TotalKilogram");
                            if (totalKilogram != null)
                            {
                                if (totalKilogram.Value != SelectedDairy.TotalKilogram.ToString())
                                {
                                    editing += "Всего кг, ";
                                }
                                totalKilogram.Value = SelectedDairy.TotalKilogram.ToString();
                            }
                            var numberOfPackages = nowEditDairy.Element("NumberOfPackages");
                            if (numberOfPackages != null)
                            {
                                if (numberOfPackages.Value != SelectedDairy.NumberOfPackages.ToString())
                                {
                                    editing += "Кол-во упаковок, ";
                                }
                                numberOfPackages.Value = SelectedDairy.NumberOfPackages.ToString();
                            }
                            var pricePerPack = nowEditDairy.Element("PricePerPack");
                            if (pricePerPack != null)
                            {
                                if (pricePerPack.Value != SelectedDairy.PricePerPack.ToString())
                                {
                                    editing += "Цена за упаковку";
                                }
                                pricePerPack.Value = SelectedDairy.PricePerPack.ToString();
                            }

                            xdoc.Save("Dairy.xml");
                        }
                    }

                    AddLog(UsersDataManageVM.ID, operation, nameOfProductLog, editing);
                    UpdateAllDataView();
                    SetNullValuesToProperties();
                    wnd.Close();
                }
                    );
            }
        }

        //изменить выбранный рыбный продукт
        private ActionCommand editFish;
        public ActionCommand EditFish
        {
            get
            {
                return editFish ?? new ActionCommand(obj =>
                {
                    string operation = "Редактирование", nameOfProductLog = null, editing = null;
                    Window wnd = obj as Window;
                    nameOfProductLog = SelectedFish.NameOfProduct;
                    if (SelectedFish != null)
                    {
                        XDocument xdoc = XDocument.Load("Fish.xml");
                        var nowEditFish = xdoc.Element("ArrayOfFish")?.Elements("Fish").FirstOrDefault(p => p.Element("ID")?.Value == SelectedFish.ID.ToString());

                        if (nowEditFish != null)
                        {
                            var nameOfProduct = nowEditFish.Element("NameOfProduct");
                            if (nameOfProduct != null)
                            {
                                if (nameOfProduct.Value != SelectedFish.NameOfProduct)
                                {
                                    editing += "Наименование, ";
                                }
                                nameOfProduct.Value = SelectedFish.NameOfProduct;
                            }
                            var pricePerKilogram = nowEditFish.Element("PricePerKilogram");
                            if (pricePerKilogram != null)
                            {
                                if (pricePerKilogram.Value != SelectedFish.PricePerKilogram.ToString())
                                {
                                    editing += "Цена за кг, ";
                                }
                                pricePerKilogram.Value = SelectedFish.PricePerKilogram.ToString();
                            }
                            var totalKilogram = nowEditFish.Element("TotalKilogram");
                            if (totalKilogram != null)
                            {
                                if (totalKilogram.Value != SelectedFish.TotalKilogram.ToString())
                                {
                                    editing += "Всего кг, ";
                                }
                                totalKilogram.Value = SelectedFish.TotalKilogram.ToString();
                            }
                            var fishCondition = nowEditFish.Element("FishCondition");
                            if (fishCondition != null)
                            {
                                if (fishCondition.Value != SelectedFish.FishCondition)
                                {
                                    editing += @"Живая\Неживая, ";
                                }
                                fishCondition.Value = SelectedFish.FishCondition;
                            }
                            var fishType = nowEditFish.Element("FishType");
                            if (fishType != null)
                            {
                                if (fishType.Value != SelectedFish.FishType)
                                {
                                    editing += "Тип рыбы";
                                }
                                fishType.Value = SelectedFish.FishType;
                            }

                            xdoc.Save("Fish.xml");
                        }
                    }

                    AddLog(UsersDataManageVM.ID, operation, nameOfProductLog, editing);
                    UpdateAllDataView();
                    SetNullValuesToProperties();
                    wnd.Close();
                }
                    );
            }
        }

        //изменить выбранный фрукт
        private ActionCommand editFruit;
        public ActionCommand EditFruit
        {
            get
            {
                return editFruit ?? new ActionCommand(obj =>
                {
                    string operation = "Редактирование", nameOfProductLog = null, editing = null;
                    Window wnd = obj as Window;
                    nameOfProductLog = SelectedFruit.NameOfProduct;
                    if (SelectedFruit != null)
                    {
                        XDocument xdoc = XDocument.Load("Fruit.xml");
                        var nowEditFruit = xdoc.Element("ArrayOfFruit")?.Elements("Fruit").FirstOrDefault(p => p.Element("ID")?.Value == SelectedFruit.ID.ToString());

                        if (nowEditFruit != null)
                        {
                            var nameOfProduct = nowEditFruit.Element("NameOfProduct");
                            if (nameOfProduct != null)
                            {
                                if (nameOfProduct.Value != SelectedFruit.NameOfProduct)
                                {
                                    editing += "Наименование, ";
                                }
                                nameOfProduct.Value = SelectedFruit.NameOfProduct;
                            }
                            var pricePerKilogram = nowEditFruit.Element("PricePerKilogram");
                            if (pricePerKilogram != null)
                            {
                                if (pricePerKilogram.Value != SelectedFruit.PricePerKilogram.ToString())
                                {
                                    editing += "Цена за кг, ";
                                }
                                pricePerKilogram.Value = SelectedFruit.PricePerKilogram.ToString();
                            }
                            var totalKilogram = nowEditFruit.Element("TotalKilogram");
                            if (totalKilogram != null)
                            {
                                if (totalKilogram.Value != SelectedFruit.TotalKilogram.ToString())
                                {
                                    editing += "Всего кг, ";
                                }
                                totalKilogram.Value = SelectedFruit.TotalKilogram.ToString();
                            }
                            var collectionDay = nowEditFruit.Element("CollectionDay");
                            if (collectionDay != null)
                            {
                                if (collectionDay.Value != SelectedFruit.CollectionDay.ToString())
                                {
                                    editing += "День сбора, ";
                                }
                                collectionDay.Value = SelectedFruit.CollectionDay.ToString();
                            }
                            var collectionMonth = nowEditFruit.Element("CollectionMonth");
                            if (collectionMonth != null)
                            {
                                if (collectionMonth.Value != SelectedFruit.CollectionMonth.ToString())
                                {
                                    editing += "Месяц сбора";
                                }
                                collectionMonth.Value = SelectedFruit.CollectionMonth.ToString();
                            }

                            xdoc.Save("Fruit.xml");
                        }
                    }

                    AddLog(UsersDataManageVM.ID, operation, nameOfProductLog, editing);
                    UpdateAllDataView();
                    SetNullValuesToProperties();
                    wnd.Close();
                }
                    );
            }
        }

        //изменить выбранный мясной продукт
        private ActionCommand editMeat;
        public ActionCommand EditMeat
        {
            get
            {
                return editMeat ?? new ActionCommand(obj =>
                {
                    string operation = "Редактирование", nameOfProductLog = null, editing = null;
                    Window wnd = obj as Window;
                    nameOfProductLog = SelectedMeat.NameOfProduct;
                    if (SelectedMeat != null)
                    {
                        XDocument xdoc = XDocument.Load("Meat.xml");
                        var nowEditMeat = xdoc.Element("ArrayOfMeat")?.Elements("Meat").FirstOrDefault(p => p.Element("ID")?.Value == SelectedMeat.ID.ToString());

                        if (nowEditMeat != null)
                        {
                            var nameOfProduct = nowEditMeat.Element("NameOfProduct");
                            if (nameOfProduct != null)
                            {
                                if (nameOfProduct.Value != SelectedMeat.NameOfProduct)
                                {
                                    editing += "Наименование, ";
                                }
                                nameOfProduct.Value = SelectedMeat.NameOfProduct;
                            }
                            var pricePerKilogram = nowEditMeat.Element("PricePerKilogram");
                            if (pricePerKilogram != null)
                            {
                                if (pricePerKilogram.Value != SelectedMeat.PricePerKilogram.ToString())
                                {
                                    editing += "Цена за кг, ";
                                }
                                pricePerKilogram.Value = SelectedMeat.PricePerKilogram.ToString();
                            }
                            var totalKilogram = nowEditMeat.Element("TotalKilogram");
                            if (totalKilogram != null)
                            {
                                if (totalKilogram.Value != SelectedMeat.TotalKilogram.ToString())
                                {
                                    editing += "Всего кг, ";
                                }
                                totalKilogram.Value = SelectedMeat.TotalKilogram.ToString();
                            }
                            var meatType = nowEditMeat.Element("MeatType");
                            if (meatType != null)
                            {
                                if (meatType.Value != SelectedMeat.MeatType)
                                {
                                    editing += "Тип мяса";
                                }
                                meatType.Value = SelectedMeat.MeatType;
                            }

                            xdoc.Save("Meat.xml");
                        }
                    }

                    AddLog(UsersDataManageVM.ID, operation, nameOfProductLog, editing);
                    UpdateAllDataView();
                    SetNullValuesToProperties();
                    wnd.Close();
                }
                    );
            }
        }

        //изменить выбранный овощ
        private ActionCommand editVegetables;
        public ActionCommand EditVegetables
        {
            get
            {
                return editVegetables ?? new ActionCommand(obj =>
                {
                    string operation = "Редактирование", nameOfProductLog = null, editing = null;
                    Window wnd = obj as Window;
                    nameOfProductLog = SelectedVegetables.NameOfProduct;
                    if (SelectedVegetables != null)
                    {
                        XDocument xdoc = XDocument.Load("Vegetables.xml");
                        var nowEditVegetables = xdoc.Element("ArrayOfVegetables")?.Elements("Vegetables").FirstOrDefault(p => p.Element("ID")?.Value == SelectedVegetables.ID.ToString());

                        if (nowEditVegetables != null)
                        {
                            var nameOfProduct = nowEditVegetables.Element("NameOfProduct");
                            if (nameOfProduct != null)
                            {
                                if (nameOfProduct.Value != SelectedVegetables.NameOfProduct)
                                {
                                    editing += "Наименование, ";
                                }
                                nameOfProduct.Value = SelectedVegetables.NameOfProduct;
                            }
                            var pricePerKilogram = nowEditVegetables.Element("PricePerKilogram");
                            if (pricePerKilogram != null)
                            {
                                if (pricePerKilogram.Value != SelectedVegetables.PricePerKilogram.ToString())
                                {
                                    editing += "Цена за кг, ";
                                }
                                pricePerKilogram.Value = SelectedVegetables.PricePerKilogram.ToString();
                            }
                            var totalKilogram = nowEditVegetables.Element("TotalKilogram");
                            if (totalKilogram != null)
                            {
                                if (totalKilogram.Value != SelectedVegetables.TotalKilogram.ToString())
                                {
                                    editing += "Всего кг, ";
                                }
                                totalKilogram.Value = SelectedVegetables.TotalKilogram.ToString();
                            }
                            var collectionDay = nowEditVegetables.Element("CollectionDay");
                            if (collectionDay != null)
                            {
                                if (collectionDay.Value != SelectedVegetables.CollectionDay.ToString())
                                {
                                    editing += "День сбора, ";
                                }
                                collectionDay.Value = SelectedVegetables.CollectionDay.ToString();
                            }
                            var collectionMonth = nowEditVegetables.Element("CollectionMonth");
                            if (collectionMonth != null)
                            {
                                if (collectionMonth.Value != SelectedVegetables.CollectionMonth.ToString())
                                {
                                    editing += "Месяц сбора";
                                }
                                collectionMonth.Value = SelectedVegetables.CollectionMonth.ToString();
                            }

                            xdoc.Save("Vegetables.xml");
                        }
                    }

                    AddLog(UsersDataManageVM.ID, operation, nameOfProductLog, editing);
                    UpdateAllDataView();
                    SetNullValuesToProperties();
                    wnd.Close();
                }
                    );
            }
        }

        #endregion

        #region COMMAND TO OPEN WINDOW

        private ActionCommand openAddNewDairyWnd;
        public ActionCommand OpenAddNewDairyWnd
        {
            get
            {
                return openAddNewDairyWnd ?? new ActionCommand(obj =>
                    {
                        XDocument xdocemployee = XDocument.Load("Employee.xml");
                        var rootemployee = xdocemployee.Element("ArrayOfEmployee")?.Elements("Employee").FirstOrDefault(p => p.Element("ID")?.Value == UsersDataManageVM.ID);
                        if (rootemployee != null)
                        {
                            var toAdd = rootemployee.Element("ToAdd");
                            if (toAdd.Value == "True")
                            {
                                OpenAddDiaryWindowMethod();
                            }
                            else
                            {
                                OpenErrorMessageWindow("У вас недостаточно прав!");
                            }
                        }
                    }
                    );
            }
        }

        private ActionCommand openAddNewFishWnd;
        public ActionCommand OpenAddNewFishWnd
        {
            get
            {
                return openAddNewFishWnd ?? new ActionCommand(obj =>
                {
                    XDocument xdocemployee = XDocument.Load("Employee.xml");
                    var rootemployee = xdocemployee.Element("ArrayOfEmployee")?.Elements("Employee").FirstOrDefault(p => p.Element("ID")?.Value == UsersDataManageVM.ID);
                    if (rootemployee != null)
                    {
                        var toAdd = rootemployee.Element("ToAdd");
                        if (toAdd.Value == "True")
                        {
                            OpenAddFishWindowMethod();
                        }
                        else
                        {
                            OpenErrorMessageWindow("У вас недостаточно прав!");
                        }
                    }
                }
                    );
            }
        }

        private ActionCommand openAddNewFruitWnd;
        public ActionCommand OpenAddNewFruitWnd
        {
            get
            {
                return openAddNewFruitWnd ?? new ActionCommand(obj =>
                {
                    XDocument xdocemployee = XDocument.Load("Employee.xml");
                    var rootemployee = xdocemployee.Element("ArrayOfEmployee")?.Elements("Employee").FirstOrDefault(p => p.Element("ID")?.Value == UsersDataManageVM.ID);
                    if (rootemployee != null)
                    {
                        var toAdd = rootemployee.Element("ToAdd");
                        if (toAdd.Value == "True")
                        {
                            OpenAddFruitWindowMethod();
                        }
                        else
                        {
                            OpenErrorMessageWindow("У вас недостаточно прав!");
                        }
                    }
                }
                    );
            }
        }

        private ActionCommand openAddNewMeatWnd;
        public ActionCommand OpenAddNewMeatWnd
        {
            get
            {
                return openAddNewMeatWnd ?? new ActionCommand(obj =>
                {
                    XDocument xdocemployee = XDocument.Load("Employee.xml");
                    var rootemployee = xdocemployee.Element("ArrayOfEmployee")?.Elements("Employee").FirstOrDefault(p => p.Element("ID")?.Value == UsersDataManageVM.ID);
                    if (rootemployee != null)
                    {
                        var toAdd = rootemployee.Element("ToAdd");
                        if (toAdd.Value == "True")
                        {
                            OpenAddMeatWindowMethod();
                        }
                        else
                        {
                            OpenErrorMessageWindow("У вас недостаточно прав!");
                        }
                    }
                }
                    );
            }
        }

        private ActionCommand openAddNewVegetablesWnd;
        public ActionCommand OpenAddNewVegetablesWnd
        {
            get
            {
                return openAddNewVegetablesWnd ?? new ActionCommand(obj =>
                {
                    XDocument xdocemployee = XDocument.Load("Employee.xml");
                    var rootemployee = xdocemployee.Element("ArrayOfEmployee")?.Elements("Employee").FirstOrDefault(p => p.Element("ID")?.Value == UsersDataManageVM.ID);
                    if (rootemployee != null)
                    {
                        var toAdd = rootemployee.Element("ToAdd");
                        if (toAdd.Value == "True")
                        {
                            OpenAddVegetablesWindowMethod();
                        }
                        else
                        {
                            OpenErrorMessageWindow("У вас недостаточно прав!");
                        }
                    }
                }
                    );
            }
        }

        private ActionCommand openEditProductWnd;
        public ActionCommand OpenEditProductWnd
        {
            get
            {
                return openEditProductWnd ?? new ActionCommand(obj =>
                {
                    XDocument xdocemployee = XDocument.Load("Employee.xml");
                    var rootemployee = xdocemployee.Element("ArrayOfEmployee")?.Elements("Employee").FirstOrDefault(p => p.Element("ID")?.Value == UsersDataManageVM.ID);
                    if (rootemployee != null)
                    {
                        var toAdd = rootemployee.Element("ToEdit");
                        if (toAdd.Value == "True")
                        {
                            //если выбран молочный продукт
                            if (SelectedTabItem.Name == "DairyTab" && SelectedDairy != null)
                            {
                                OpenEditDiaryWindowMethod(SelectedDairy);
                            }

                            //если выбран рыбный продукт
                            if (SelectedTabItem.Name == "FishTab" && SelectedFish != null)
                            {
                                OpenEditFishWindowMethod(SelectedFish);
                            }

                            //если выбран фрукт
                            if (SelectedTabItem.Name == "FruitTab" && SelectedFruit != null)
                            {
                                OpenEditFruitWindowMethod(SelectedFruit);
                            }

                            //если выбран мясной продукт
                            if (SelectedTabItem.Name == "MeatTab" && SelectedMeat != null)
                            {
                                OpenEditMeatWindowMethod(SelectedMeat);
                            }

                            //если выбран овощ
                            if (SelectedTabItem.Name == "VegetablesTab" && SelectedVegetables != null)
                            {
                                OpenEditVegetablesWindowMethod(SelectedVegetables);
                            }
                        }
                        else
                        {
                            OpenErrorMessageWindow("У вас недостаточно прав!");
                        }
                    }
                }
                    );
            }
        }

        private ActionCommand openReserveProductWnd;
        public ActionCommand OpenReserveProductWnd
        {
            get
            {
                return openReserveProductWnd ?? new ActionCommand(obj =>
                {
                    //если выбран молочный продукт
                    if (SelectedTabItem.Name == "DairyTab" && SelectedDairy != null)
                    {
                        OpenReserveDairyWindowMethod(SelectedDairy);
                    }

                    //если выбран рыбный продукт
                    if (SelectedTabItem.Name == "FishTab" && SelectedFish != null)
                    {
                        OpenReserveFishWindowMethod(SelectedFish);
                    }

                    //если выбран фрукт
                    if (SelectedTabItem.Name == "FruitTab" && SelectedFruit != null)
                    {
                        OpenReserveFruitWindowMethod(SelectedFruit);
                    }

                    //если выбран мясной продукт
                    if (SelectedTabItem.Name == "MeatTab" && SelectedMeat != null)
                    {
                        OpenReserveMeatWindowMethod(SelectedMeat);
                    }

                    //если выбран овощ
                    if (SelectedTabItem.Name == "VegetablesTab" && SelectedVegetables != null)
                    {
                        OpenReserveVegetablesWindowMethod(SelectedVegetables);
                    }
                }
                    );
            }
        }

        private ActionCommand clientToBack;
        public ActionCommand ClientToBack
        {
            get
            {
                return clientToBack ?? new ActionCommand(obj =>
                {
                    Window wnd = obj as Window;
                    OpenToBackClientInterfaceMetod();
                    wnd.Close();
                }
                    );
            }
        }

        private ActionCommand openOrdersWindow;
        public ActionCommand OpenOrdersWindow
        {
            get
            {
                return openOrdersWindow ?? new ActionCommand(obj =>
                {
                    Window wnd = obj as Window;
                    OpenOrdersWindowMetod();
                    wnd.Close();
                }
                    );
            }
        }

        private ActionCommand openEmployeeToBackInterface;
        public ActionCommand OpenEmployeeToBackInterface
        {
            get
            {
                return openEmployeeToBackInterface ?? new ActionCommand(obj =>
                {
                    Window wnd = obj as Window;
                    OpenEmployeeToBackInterfaceMetod();
                    wnd.Close();
                }
                    );
            }
        }

        private ActionCommand openAcknowledgmentOrdersWindow;
        public ActionCommand OpenAcknowledgmentOrdersWindow
        {
            get
            {
                return openAcknowledgmentOrdersWindow ?? new ActionCommand(obj =>
                {
                    Window wnd = obj as Window;
                    OpenAcknowledgmentOrdersWindowMetod();
                    wnd.Close();
                }
                    );
            }
        }

        private ActionCommand openPermissionWindow;
        public ActionCommand OpenPermissionWindow
        {
            get
            {
                return openPermissionWindow ?? new ActionCommand(obj =>
                {
                    OpenPermissionWindowMetod(SelectedEmployee);
                }
                    );
            }
        }

        private ActionCommand openRegistrationEmployeeWnd;
        public ActionCommand OpenRegistrationEmployeeWnd
        {
            get
            {
                return openRegistrationEmployeeWnd ?? new ActionCommand(obj =>
                {
                    OpenRegistrationEmployeeWindowMetod();
                }
                    );
            }
        }

        #endregion

        #region METOD TO OPEN WINDOW
        //методы открытия окон для добавления и редактирования

        //открыть окно для добавления молочного продукта
        private void OpenAddDiaryWindowMethod()
        {
            AddNewDiaryWindow newDiaryWindow = new AddNewDiaryWindow();
            newDiaryWindow.ShowDialog();
        }

        //открыть окно для добавления рыбного продукта
        private void OpenAddFishWindowMethod()
        {
            AddNewFishWindow newFishWindow = new AddNewFishWindow();
            newFishWindow.ShowDialog();
        }

        //открыть окно для добавления фрукта
        private void OpenAddFruitWindowMethod()
        {
            AddNewFruitWindow newFruitWindow = new AddNewFruitWindow();
            newFruitWindow.ShowDialog();
        }

        //открыть окно для добавления мясного продукта
        private void OpenAddMeatWindowMethod()
        {
            AddNewMeatWindow newMeatWindow = new AddNewMeatWindow();
            newMeatWindow.ShowDialog();
        }

        //открыть окно для добавления овоща
        private void OpenAddVegetablesWindowMethod()
        {
            AddNewVegetablesWindow newVegetablesWindow = new AddNewVegetablesWindow();
            newVegetablesWindow.ShowDialog();
        }

        //открыть окно для редактирования молочного продукта
        private void OpenEditDiaryWindowMethod(Dairy dairy)
        {
            EditDiaryWindow newDiaryWindow = new EditDiaryWindow(dairy);
            newDiaryWindow.ShowDialog();
        }

        //открыть окно для редактирования рыбного продукта
        private void OpenEditFishWindowMethod(Fish fish)
        {
            EditFishWindow newFishWindow = new EditFishWindow(fish);
            newFishWindow.ShowDialog();
        }

        //открыть окно для редактирования фрукта
        private void OpenEditFruitWindowMethod(Fruit fruit)
        {
            EditFruitWindow newFruitWindow = new EditFruitWindow(fruit);
            newFruitWindow.ShowDialog();
        }

        //открыть окно для редактирования мясного продукта
        private void OpenEditMeatWindowMethod(Meat meat)
        {
            EditMeatWindow newMeatWindow = new EditMeatWindow(meat);
            newMeatWindow.ShowDialog();
        }

        //открыть окно для редактирования овоща
        private void OpenEditVegetablesWindowMethod(Vegetables vegetables)
        {
            EditVegetablesWindow newVegetablesWindow = new EditVegetablesWindow(vegetables);
            newVegetablesWindow.ShowDialog();
        }

        //открыть окно для сообщения о добавлении продукта
        private void ShowMessageToUser()
        {
            MessageViewWindow messageView = new MessageViewWindow();
            messageView.ShowDialog();
        }

        public void OpenErrorMessageWindow(string str)
        {
            ErrorMessageWindow errorMessageWindow = new ErrorMessageWindow(str);
            errorMessageWindow.ShowDialog();
        }

        private void OpenReserveDairyWindowMethod(Dairy dairy)
        {
            ReserveDairyWindow reserveDairyWindow = new ReserveDairyWindow(dairy);
            reserveDairyWindow.ShowDialog();
        }

        private void OpenReserveFishWindowMethod(Fish fish)
        {
            ReserveFishWindow reserveFishWindow = new ReserveFishWindow(fish);
            reserveFishWindow.ShowDialog();
        }

        private void OpenReserveFruitWindowMethod(Fruit fruit)
        {
            ReserveFruitWindow reserveFruitWindow = new ReserveFruitWindow(fruit);
            reserveFruitWindow.ShowDialog();
        }

        private void OpenReserveMeatWindowMethod(Meat meat)
        {
            ReserveMeatWindow reserveMeatWindow = new ReserveMeatWindow(meat);
            reserveMeatWindow.ShowDialog();
        }

        private void OpenReserveVegetablesWindowMethod(Vegetables vegetables)
        {
            ReserveVegetablesWindow reserveVegetablesWindow = new ReserveVegetablesWindow(vegetables);
            reserveVegetablesWindow.ShowDialog();
        }

        private void OpenToBackClientInterfaceMetod()
        {
            ClientInterface clientInterface = new ClientInterface();
            clientInterface.Show();
        }

        private void OpenEmployeeToBackInterfaceMetod()
        {
            ProductsWindow productsWindow = new ProductsWindow();
            productsWindow.Show();
        }

        private void OpenOrdersWindowMetod()
        {
            OrdersWindow ordersWindow = new OrdersWindow();
            ordersWindow.Show();
        }

        private void OpenAcknowledgmentOrdersWindowMetod()
        {
            AcknowledgmentOrdersWindow acknowledgmentOrdersWindow = new AcknowledgmentOrdersWindow();
            acknowledgmentOrdersWindow.Show();
        }

        private void OpenPermissionWindowMetod(Employee employee)
        {
            PermissionWindow permissionWindow = new PermissionWindow(employee);
            permissionWindow.ShowDialog();
        }

        private void OpenRegistrationEmployeeWindowMetod()
        {
            RegistrationEmployeeWindow registrationEmployeeWindow = new RegistrationEmployeeWindow();
            registrationEmployeeWindow.ShowDialog();
        }

        #endregion

        #region UPDATE VIEWS

        private void SetNullValuesToProperties()
        {
            //для всех
            NameOfProduct = null;
            PricePerKilogram = 0;
            TotalKilogram = 0;

            //для молочных продуктов
            NumberOfPackages = 0;
            PricePerPack = 0;

            //для рыбных продуктов
            FishCondition = null;
            FishType = null;

            //для фруктов
            CollectionDay = 0;
            CollectionMonth = 0;

            //для мясных продуктов
            MeatType = null;

            //для овощей
            CollectionDay = 0;
            CollectionMonth = 0;
        }

        private void UpdateAllDataView()
        {
            UpdateAllDairiesView();
            UpdateAllFishesView();
            UpdateAllFruitView();
            UpdateAllMeatView();
            UpdateAllVegetablesView();
        }

        private void UpdateAllDataViewClientInterface()
        {
            UpdateAllDairiesViewClientInterface();
            UpdateAllFishesViewClientInterface();
            UpdateAllFruitViewClientInterface();
            UpdateAllMeatViewClientInterface();
            UpdateAllVegetablesViewClientInterface();
        }

        private void UpdateAllDairiesView()
        {
            ProductsWindow.AllDairiesView.ItemsSource = null;
            ProductsWindow.AllDairiesView.Items.Clear();
            ProductsWindow.AllDairiesView.ItemsSource = Dairies;
            ProductsWindow.AllDairiesView.Items.Refresh();
        }

        private void UpdateAllFishesView()
        {
            ProductsWindow.AllFishesView.ItemsSource = null;
            ProductsWindow.AllFishesView.Items.Clear();
            ProductsWindow.AllFishesView.ItemsSource = Fishes;
            ProductsWindow.AllFishesView.Items.Refresh();
        }

        private void UpdateAllFruitView()
        {
            ProductsWindow.AllFruitView.ItemsSource = null;
            ProductsWindow.AllFruitView.Items.Clear();
            ProductsWindow.AllFruitView.ItemsSource = Fruit;
            ProductsWindow.AllFruitView.Items.Refresh();
        }

        private void UpdateAllMeatView()
        {
            ProductsWindow.AllMeatView.ItemsSource = null;
            ProductsWindow.AllMeatView.Items.Clear();
            ProductsWindow.AllMeatView.ItemsSource = Meat;
            ProductsWindow.AllMeatView.Items.Refresh();
        }

        private void UpdateAllVegetablesView()
        {
            ProductsWindow.AllVegetablesView.ItemsSource = null;
            ProductsWindow.AllVegetablesView.Items.Clear();
            ProductsWindow.AllVegetablesView.ItemsSource = Vegetables;
            ProductsWindow.AllVegetablesView.Items.Refresh();
        }

        private void UpdateAllDairiesViewClientInterface()
        {
            ClientInterface.AllDairiesView.ItemsSource = null;
            ClientInterface.AllDairiesView.Items.Clear();
            ClientInterface.AllDairiesView.ItemsSource = Dairies;
            ClientInterface.AllDairiesView.Items.Refresh();
        }

        private void UpdateAllFishesViewClientInterface()
        {
            ClientInterface.AllFishesView.ItemsSource = null;
            ClientInterface.AllFishesView.Items.Clear();
            ClientInterface.AllFishesView.ItemsSource = Fishes;
            ClientInterface.AllFishesView.Items.Refresh();
        }

        private void UpdateAllFruitViewClientInterface()
        {
            ClientInterface.AllFruitView.ItemsSource = null;
            ClientInterface.AllFruitView.Items.Clear();
            ClientInterface.AllFruitView.ItemsSource = Fruit;
            ClientInterface.AllFruitView.Items.Refresh();
        }

        private void UpdateAllMeatViewClientInterface()
        {
            ClientInterface.AllMeatView.ItemsSource = null;
            ClientInterface.AllMeatView.Items.Clear();
            ClientInterface.AllMeatView.ItemsSource = Meat;
            ClientInterface.AllMeatView.Items.Refresh();
        }

        private void UpdateAllVegetablesViewClientInterface()
        {
            ClientInterface.AllVegetablesView.ItemsSource = null;
            ClientInterface.AllVegetablesView.Items.Clear();
            ClientInterface.AllVegetablesView.ItemsSource = Vegetables;
            ClientInterface.AllVegetablesView.Items.Refresh();
        }

        private void UpdateAcknowledgmentOrders()
        {
            AcknowledgmentOrdersWindow.AllReservationProductsView.ItemsSource = null;
            AcknowledgmentOrdersWindow.AllReservationProductsView.Items.Clear();
            AcknowledgmentOrdersWindow.AllReservationProductsView.ItemsSource = ReservationProductsAll;
            AcknowledgmentOrdersWindow.AllReservationProductsView.Items.Refresh();
        }

        private void UpdateOrders()
        {
            OrdersWindow.AllReservationProductsIDView.ItemsSource = null;
            OrdersWindow.AllReservationProductsIDView.Items.Clear();
            OrdersWindow.AllReservationProductsIDView.ItemsSource = ReservationProductsID;
            OrdersWindow.AllReservationProductsIDView.Items.Refresh();
        }

        private void UpdateEmployees()
        {
            AdminInterface.AllEmployeesView.ItemsSource = null;
            AdminInterface.AllEmployeesView.Items.Clear();
            AdminInterface.AllEmployeesView.ItemsSource = Employee;
            AdminInterface.AllEmployeesView.Items.Refresh();
        }

        #endregion

        #region COMMAND TO OUTPUT

        private ActionCommand closeUserInterface;
        public ActionCommand CloseUserInterface
        {
            get
            {
                return closeUserInterface ?? new ActionCommand(obj =>
                {
                    Window wnd = obj as Window;
                    InputWindow inputWindow = new InputWindow();
                    inputWindow.Show();
                    UsersDataManageVM.ID = null;
                    wnd.Close();
                }
                    );
            }
        }

        #endregion

        #region COMMAND TO RESERVATION

        public static int WeightReserve { get; set; }
        private void ReservationProductMetod(string SelectedName)
        {
            string operation = "Резервирование", nameOfProductLog = SelectedName, editing = "Всего кг";
            ObservableCollection<ReservationProduct> reservationProducts = new ObservableCollection<ReservationProduct>();
            ReservationProduct reservationProduct = new ReservationProduct();
            reservationProduct.IDOfClient = UsersDataManageVM.ID;
            reservationProduct.Name = SelectedName;
            reservationProduct.Weight = WeightReserve;
            reservationProduct.Condition = "В обработке";
            reservationProducts.Add(reservationProduct);

            if (!File.Exists("ReservationProduct.xml"))
            {
                DataProducts dataProducts = new DataProducts();
                dataProducts.SaveFirstData(reservationProducts, "ReservationProduct");
            }

            else
            {
                XDocument xdoc = XDocument.Load("ReservationProduct.xml");
                XElement root = xdoc.Element("ArrayOfReservationProduct");

                if (root != null)
                {
                    // добавляем новый элемент
                    root.Add(new XElement("ReservationProduct",
                                new XElement("IDOfClient", UsersDataManageVM.ID),
                                new XElement("Name", SelectedName),
                                new XElement("Weight", WeightReserve),
                                new XElement("Condition", "В обработке")));

                    xdoc.Save("ReservationProduct.xml");
                    AddLog(UsersDataManageVM.ID, operation, nameOfProductLog, editing);
                }
            }
        }

        private ActionCommand reserveDairy;
        public ActionCommand ReserveDairy
        {
            get
            {
                return reserveDairy ?? new ActionCommand(obj =>
                {
                    Window wnd = obj as Window;
                    ReservationProductMetod(SelectedDairy.NameOfProduct);

                    XDocument xdoc1 = XDocument.Load("Dairy.xml");
                    var nowReservedDairy = xdoc1.Element("ArrayOfDairy")?.Elements("Dairy").FirstOrDefault(p => p.Element("ID")?.Value == SelectedDairy.ID.ToString());
                    if (nowReservedDairy != null)
                    {
                        var totalKilogram = nowReservedDairy.Element("TotalKilogram");
                        if ((int)totalKilogram - WeightReserve >= 0)
                        {
                            var Totalkilogram = Convert.ToInt32(totalKilogram.Value) - WeightReserve;
                            if(Totalkilogram == 0)
                            {
                                nowReservedDairy.Remove();
                                xdoc1.Save("Dairy.xml");
                            }
                            else
                            {
                                totalKilogram.Value = Totalkilogram.ToString();
                                xdoc1.Save("Dairy.xml");
                            }
                        }
                        else
                        {
                            OpenErrorMessageWindow("У нас нет на складе данного продукта в таком количестве!");
                        }
                    }

                    UpdateAllDataViewClientInterface();
                    WeightReserve = 0;
                    wnd.Close();
                }
                    );
            }
        }

        private ActionCommand reserveFish;
        public ActionCommand ReserveFish
        {
            get
            {
                return reserveFish ?? new ActionCommand(obj =>
                {
                    Window wnd = obj as Window;
                    ReservationProductMetod(SelectedFish.NameOfProduct);

                    XDocument xdoc1 = XDocument.Load("Fish.xml");
                    var nowReservedFish = xdoc1.Element("ArrayOfFish")?.Elements("Fish").FirstOrDefault(p => p.Element("ID")?.Value == SelectedFish.ID.ToString());
                    if (nowReservedFish != null)
                    {
                        var totalKilogram = nowReservedFish.Element("TotalKilogram");
                        if ((int)totalKilogram - WeightReserve >= 0)
                        {
                            var Totalkilogram = Convert.ToInt32(totalKilogram.Value) - WeightReserve;
                            if (Totalkilogram == 0)
                            {
                                nowReservedFish.Remove();
                                xdoc1.Save("Fish.xml");
                            }
                            else
                            {
                                totalKilogram.Value = Totalkilogram.ToString();
                                xdoc1.Save("Fish.xml");
                            }
                        }
                        else
                        {
                            OpenErrorMessageWindow("У нас нет на складе данного продукта в таком количестве!");
                        }
                    }

                    UpdateAllDataViewClientInterface();
                    WeightReserve = 0;
                    wnd.Close();
                }
                    );
            }
        }

        private ActionCommand reserveFruit;
        public ActionCommand ReserveFruit
        {
            get
            {
                return reserveFruit ?? new ActionCommand(obj =>
                {
                    Window wnd = obj as Window;
                    ReservationProductMetod(SelectedFruit.NameOfProduct);

                    XDocument xdoc1 = XDocument.Load("Fruit.xml");
                    var nowReservedFruit = xdoc1.Element("ArrayOfFruit")?.Elements("Fruit").FirstOrDefault(p => p.Element("ID")?.Value == SelectedFruit.ID.ToString());
                    if (nowReservedFruit != null)
                    {
                        var totalKilogram = nowReservedFruit.Element("TotalKilogram");
                        if ((int)totalKilogram - WeightReserve >= 0)
                        {
                            var Totalkilogram = Convert.ToInt32(totalKilogram.Value) - WeightReserve;
                            if (Totalkilogram == 0)
                            {
                                nowReservedFruit.Remove();
                                xdoc1.Save("Fruit.xml");
                            }
                            else
                            {
                                totalKilogram.Value = Totalkilogram.ToString();
                                xdoc1.Save("Fruit.xml");
                            }
                        }
                        else
                        {
                            OpenErrorMessageWindow("У нас нет на складе данного продукта в таком количестве!");
                        }
                    }

                    UpdateAllDataViewClientInterface();
                    WeightReserve = 0;
                    wnd.Close();
                }
                    );
            }
        }

        private ActionCommand reserveMeat;
        public ActionCommand ReserveMeat
        {
            get
            {
                return reserveMeat ?? new ActionCommand(obj =>
                {
                    Window wnd = obj as Window;
                    ReservationProductMetod(SelectedMeat.NameOfProduct);

                    XDocument xdoc1 = XDocument.Load("Meat.xml");
                    var nowReservedMeat = xdoc1.Element("ArrayOfMeat")?.Elements("Meat").FirstOrDefault(p => p.Element("ID")?.Value == SelectedMeat.ID.ToString());
                    if (nowReservedMeat != null)
                    {
                        var totalKilogram = nowReservedMeat.Element("TotalKilogram");
                        if ((int)totalKilogram - WeightReserve >= 0)
                        {
                            var Totalkilogram = Convert.ToInt32(totalKilogram.Value) - WeightReserve;
                            if (Totalkilogram == 0)
                            {
                                nowReservedMeat.Remove();
                                xdoc1.Save("Meat.xml");
                            }
                            else
                            {
                                totalKilogram.Value = Totalkilogram.ToString();
                                xdoc1.Save("Meat.xml");
                            }
                        }
                        else
                        {
                            OpenErrorMessageWindow("У нас нет на складе данного продукта в таком количестве!");
                        }
                    }

                    UpdateAllDataViewClientInterface();
                    WeightReserve = 0;
                    wnd.Close();
                }
                    );
            }
        }
        
        private ActionCommand reserveVegetables;
        public ActionCommand ReserveVegetables
        {
            get
            {
                return reserveVegetables ?? new ActionCommand(obj =>
                {
                    Window wnd = obj as Window;
                    ReservationProductMetod(SelectedVegetables.NameOfProduct);

                    XDocument xdoc1 = XDocument.Load("Vegetables.xml");
                    var nowReservedVegetables = xdoc1.Element("ArrayOfVegetables")?.Elements("Vegetables").FirstOrDefault(p => p.Element("ID")?.Value == SelectedVegetables.ID.ToString());
                    if (nowReservedVegetables != null)
                    {
                        var totalKilogram = nowReservedVegetables.Element("TotalKilogram");
                        if ((int)totalKilogram - WeightReserve >= 0)
                        {
                            var Totalkilogram = Convert.ToInt32(totalKilogram.Value) - WeightReserve;
                            if (Totalkilogram == 0)
                            {
                                nowReservedVegetables.Remove();
                                xdoc1.Save("Vegetables.xml");
                            }
                            else
                            {
                                totalKilogram.Value = Totalkilogram.ToString();
                                xdoc1.Save("Vegetables.xml");
                            }
                        }
                        else
                        {
                            OpenErrorMessageWindow("У нас нет на складе данного продукта в таком количестве!");
                        }
                    }

                    UpdateAllDataViewClientInterface();
                    WeightReserve = 0;
                    wnd.Close();
                }
                    );
            }
        }

        #endregion

        #region COMMAND TO ACKNOWLEDGE AND REFUSE RESERVATION

        private ActionCommand acknowledgeProduct;
        public ActionCommand AcknowledgeProduct
        {
            get
            {
                return acknowledgeProduct ?? new ActionCommand(obj =>
                {
                    string operation = "Подтверждение", nameOfProductLog = SelectedReservationProduct.Name, editing = "Статус заказа";
                    if (SelectedReservationProduct != null)
                    {
                        XDocument xdoc = XDocument.Load("ReservationProduct.xml");
                        var reservationProduct = xdoc.Element("ArrayOfReservationProduct")?.Elements("ReservationProduct").FirstOrDefault(
                            p => p.Element("IDOfClient")?.Value == SelectedReservationProduct.IDOfClient.ToString() && 
                            p.Element("Name")?.Value == SelectedReservationProduct.Name &&
                            p.Element("Weight")?.Value == SelectedReservationProduct.Weight.ToString());
                        if (reservationProduct != null)
                        {
                            var ConditionOfProduct = reservationProduct.Element("Condition");
                            if (ConditionOfProduct != null) ConditionOfProduct.Value = "Резервация подтверждена";
                            xdoc.Save("ReservationProduct.xml");

                            AddLog(UsersDataManageVM.ID, operation, nameOfProductLog, editing);

                            UpdateAcknowledgmentOrders();
                        }
                    }
                }
                    );
            }
        }

        private ActionCommand refuseProduct;
        public ActionCommand RefuseProduct
        {
            get
            {
                return refuseProduct ?? new ActionCommand(obj =>
                {
                    string operation = "Отклонение", nameOfProductLog = SelectedReservationProduct.Name, editing = "Статус заказа";
                    if (SelectedReservationProduct != null)
                    {
                        XDocument xdoc = XDocument.Load("ReservationProduct.xml");
                        var reservationProduct = xdoc.Element("ArrayOfReservationProduct")?.Elements("ReservationProduct").FirstOrDefault(
                            p => p.Element("IDOfClient")?.Value == SelectedReservationProduct.IDOfClient.ToString() &&
                            p.Element("Name")?.Value == SelectedReservationProduct.Name &&
                            p.Element("Weight")?.Value == SelectedReservationProduct.Weight.ToString());
                        if (reservationProduct != null)
                        {
                            var ConditionOfProduct = reservationProduct.Element("Condition");
                            if (ConditionOfProduct != null) ConditionOfProduct.Value = "Резервация отклонена";
                            xdoc.Save("ReservationProduct.xml");

                            AddLog(UsersDataManageVM.ID, operation, nameOfProductLog, editing);

                            XDocument xdocDairy = XDocument.Load("Dairy.xml");
                            var refuseDairy = xdocDairy.Element("ArrayOfDairy")?.Elements("Dairy").FirstOrDefault(p => p.Element("NameOfProduct")?.Value == SelectedReservationProduct.Name);
                            if(refuseDairy != null)
                            {
                                var totalkilogram = refuseDairy.Element("TotalKilogram");
                                totalkilogram.Value = (Convert.ToInt32(totalkilogram.Value) + SelectedReservationProduct.Weight).ToString();
                                xdocDairy.Save("Dairy.xml");
                            }
                            XDocument xdocFish = XDocument.Load("Fish.xml");
                            var refuseFish = xdocFish.Element("ArrayOfFish")?.Elements("Fish").FirstOrDefault(p => p.Element("NameOfProduct")?.Value == SelectedReservationProduct.Name);
                            if (refuseFish != null)
                            {
                                var totalkilogram = refuseFish.Element("TotalKilogram");
                                totalkilogram.Value = (Convert.ToInt32(totalkilogram.Value) + SelectedReservationProduct.Weight).ToString();
                                xdocFish.Save("Fish.xml");
                            }
                            XDocument xdocFruit = XDocument.Load("Fruit.xml");
                            var refuseFruit = xdocFruit.Element("ArrayOfFruit")?.Elements("Fruit").FirstOrDefault(p => p.Element("NameOfProduct")?.Value == SelectedReservationProduct.Name);
                            if (refuseFruit != null)
                            {
                                var totalkilogram = refuseFruit.Element("TotalKilogram");
                                totalkilogram.Value = (Convert.ToInt32(totalkilogram.Value) + SelectedReservationProduct.Weight).ToString();
                                xdocFruit.Save("Fruit.xml");
                            }
                            XDocument xdocMeat = XDocument.Load("Meat.xml");
                            var refuseMeat = xdocMeat.Element("ArrayOfMeat")?.Elements("Meat").FirstOrDefault(p => p.Element("NameOfProduct")?.Value == SelectedReservationProduct.Name);
                            if (refuseMeat != null)
                            {
                                var totalkilogram = refuseMeat.Element("TotalKilogram");
                                totalkilogram.Value = (Convert.ToInt32(totalkilogram.Value) + SelectedReservationProduct.Weight).ToString();
                                xdocMeat.Save("Meat.xml");
                            }
                            XDocument xdocVegetables = XDocument.Load("Vegetables.xml");
                            var refuseVegetables = xdocVegetables.Element("ArrayOfVegetables")?.Elements("Vegetables").FirstOrDefault(p => p.Element("NameOfProduct")?.Value == SelectedReservationProduct.Name);
                            if (refuseVegetables != null)
                            {
                                var totalkilogram = refuseVegetables.Element("TotalKilogram");
                                totalkilogram.Value = (Convert.ToInt32(totalkilogram.Value) + SelectedReservationProduct.Weight).ToString();
                                xdocVegetables.Save("Vegetables.xml");
                            }

                            UpdateAcknowledgmentOrders();
                            UpdateAllDataView();
                        }
                    }
                }
                    );
            }
        }

        #endregion

        #region COMMAND TO DELETE AND REFUSE RESERVATION

        private ActionCommand deleteReservation;
        public ActionCommand DeleteReservation
        {
            get
            {
                return deleteReservation ?? new ActionCommand(obj =>
                {
                    string operation = @"Уведомление о получении\отмене заказа", nameOfProductLog = SelectedReservationProduct.Name, editing = "ID клиента, Наименование продукта, Зарезервированно кг, Статус заказа";
                    XDocument xdoc = XDocument.Load("ReservationProduct.xml");
                    var reservationProduct = xdoc.Element("ArrayOfReservationProduct")?.Elements("ReservationProduct").FirstOrDefault(
                            p => p.Element("IDOfClient")?.Value == SelectedReservationProduct.IDOfClient.ToString() &&
                            p.Element("Name")?.Value == SelectedReservationProduct.Name &&
                            p.Element("Weight")?.Value == SelectedReservationProduct.Weight.ToString() &&
                            p.Element("Condition")?.Value != "В обработке");
                    if (reservationProduct != null)
                    {
                        reservationProduct.Remove();
                        xdoc.Save("ReservationProduct.xml");
                        AddLog(UsersDataManageVM.ID, operation, nameOfProductLog, editing);
                        UpdateOrders();
                    }
                }
                    );
            }
        }

        #endregion

        #region REGISTER EMPLOYEE

        public static string Login { get; set; }
        public static string Password { get; set; }
        public static string SecondPassword { get; set; }
        public static string Email { get; set; }
        public static string PhoneNumber { get; set; }

        //регистрация рабочих
        private ActionCommand addNewEmployee;
        public ActionCommand AddNewEmployee
        {
            get
            {
                return addNewEmployee ?? new ActionCommand(obj =>
                {
                    Window wnd = obj as Window;
                    XDocument xdoc1 = XDocument.Load("Client.xml");
                    var loginClient = xdoc1.Element("ArrayOfClient")?.Elements("Client").FirstOrDefault(p => p.Element("Login")?.Value == Login);
                    XDocument xdoc2 = XDocument.Load("Employee.xml");
                    var loginEmployee = xdoc2.Element("ArrayOfEmployee")?.Elements("Employee").FirstOrDefault(p => p.Element("Login")?.Value == Login);
                    XDocument xdoc3 = XDocument.Load("Admin.xml");
                    var loginAdmin = xdoc3.Element("ArrayOfAdmin")?.Elements("Admin").FirstOrDefault(p => p.Element("Login")?.Value == Login);

                    string errorStr = "";
                    if (Login == null || Login.Length < 5 || Login.Replace(" ", "").Length == 0)
                    {
                        errorStr = "Слишком короткий логин!";
                        OpenErrorMessageWindow(errorStr);
                    }
                    else if (loginClient != null || loginEmployee != null || loginAdmin != null)
                    {
                        errorStr = "Данный логин уже существует!";
                        OpenErrorMessageWindow(errorStr);
                    }
                    else if (Password == null || Password.Length < 8 || Password.Replace(" ", "").Length == 0)
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
                        ObservableCollection<Employee> employees = new ObservableCollection<Employee>();
                        Employee employee = new Employee();
                        employee.ID = rnd.Next(0, 1000);
                        employee.Login = Login;
                        employee.Password = Password;
                        employee.Email = Email;
                        employee.PhoneNumber = PhoneNumber;
                        employee.ToAdd = "True";
                        employee.ToEdit = "False";
                        employee.ToDelete = "False";
                        employees.Add(employee);

                        if (!File.Exists("Employee.xml"))
                        {
                            DataProducts dataProducts = new DataProducts();
                            dataProducts.SaveFirstData(employees, "Employee");
                        }

                        else
                        {
                            XDocument xdoc = XDocument.Load("Employee.xml");
                            XElement root = xdoc.Element("ArrayOfEmployee");

                            if (root != null)
                            {
                                root.Add(new XElement("Employee",
                                            new XElement("ID", rnd.Next(0, 1000)),
                                            new XElement("Login", Login),
                                            new XElement("Password", Password),
                                            new XElement("Email", Email),
                                            new XElement("PhoneNumber", PhoneNumber),
                                            new XElement("TypeOfUser", employee.TypeOfUser),
                                            new XElement("ToAdd", "True"),
                                            new XElement("ToEdit", "False"),
                                            new XElement("ToDelete", "False")));
                                xdoc.Save("Employee.xml");
                            }
                        }

                        UpdateEmployees();
                        SetNullValuesToPropertiesUser();
                        wnd.Close();
                    }
                }
                    );
            }
        }

        private void SetNullValuesToPropertiesUser()
        {
            Login = null;
            Password = null;
            SecondPassword = null;
            Email = null;
            PhoneNumber = null;
        }

        #endregion

        #region EDIT PERMISSION

        //Выбор ответов для редактирования доступа
        private ObservableCollection<string> allAnsvers;
        public ObservableCollection<string> AllAnsvers
        {
            get
            {
                allAnsvers = new ObservableCollection<string>();
                allAnsvers.Add("True");
                allAnsvers.Add("False");
                return allAnsvers;
            }
        }

        private ActionCommand editPermission;
        public ActionCommand EditPermission
        {
            get
            {
                return editPermission ?? new ActionCommand(obj =>
                {
                    Window wnd = obj as Window;
                    if (SelectedEmployee != null)
                    {
                        XDocument xdoc = XDocument.Load("Employee.xml");
                        var employee = xdoc.Element("ArrayOfEmployee")?.Elements("Employee").FirstOrDefault(p => p.Element("ID")?.Value == SelectedEmployee.ID.ToString());
                        if (employee != null)
                        {
                            var employeeToAdd = employee.Element("ToAdd");
                            if (employeeToAdd != null) employeeToAdd.Value = SelectedEmployee.ToAdd;

                            var employeeToEdit = employee.Element("ToEdit");
                            if (employeeToEdit != null) employeeToEdit.Value = SelectedEmployee.ToEdit;

                            var employeeToDelete = employee.Element("ToDelete");
                            if (employeeToDelete != null) employeeToDelete.Value = SelectedEmployee.ToDelete;

                            xdoc.Save("Employee.xml");
                        }
                    }

                    wnd.Close();
                }
                    );
            }
        }

        #endregion
    }
}
