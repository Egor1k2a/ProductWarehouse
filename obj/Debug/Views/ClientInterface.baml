   M S B A M L   `   `   `  ????K  GProductWarehouse, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null?$clr-namespace:ProductWarehouse.ViewsProductWarehouse.Views  5   	   I)clr-namespace:ProductWarehouse.ViewModelsProductWarehouse.ViewModels  6<   ,    &ProductWarehouse.Views.ClientInterface   5   	   \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   6local$clr-namespace:ProductWarehouse.Views     5   	   ?	viewModel)clr-namespace:ProductWarehouse.ViewModels     6<   -   5        $??ClientInterfaceWnd??5	   	     ? Title$  ClientInterface??5   	   $	??600??6!   $	??900??6.    ? 	Resources 5
      ,   &ProductWarehouse.ViewModels.DataManage   viewModelSourse??%   &	          5   
   6   5       ? DataContext 5      ?? 5   
    ?? Source# [  6   .??5      ?  ? RowDefinitions 5   
   ?? 5      $??* ?6   ?? 5      $??50 ?6   .+?5   
   ?? $??0??6    ?? SelectedItem 6"   ?? *SelectedTabItem+.@?5      ?? -   5        $??MeatTab??5      ??5      ?? 5      $#??Мясные продукты??6     ? ContextMenu 5      ?? 5      .@?5      m? $$??Зарезервировать??6#    m? Command 6<   ?? *OpenReserveProductWnd+5      .??5      ?? -   5         ??Name$ ViewAllMeat??5      ??60   ?? *Meat+ 6M   ?? *SelectedMeat+	 ?? View	 5       ?? 5!      .P?5"      ?? $??ID??6-   
 ?? DisplayMemberBinding
 69   ??  ?? Path$ ID??? 5#      $??Наименование??6-   
 6C   ?? $ NameOfProduct??? 5$      $??Цена за кг??6-   
 6A   ?? $ PricePerKilogram??? 5%      $??Всего кг??6-   
 6?   ?? $ TotalKilogram??? 5&      $??Тип мяса??6-   
 6?   ?? $ MeatType?5'      5)      5*      ?? 5+      -   5        $??FishTab??5+      ??5,      ?? 5-      $#??Рыбные продукты??6     5/      ?? 50      .@?51      m? $$??Зарезервировать??6#    6<   ?? *OpenReserveProductWnd+52      .??54      ?? -   5        $ ViewAllFishes??54      ??62   ?? *Fishes+ 6Q   ?? *SelectedFish+	 55      ?? 56      .P?57      ?? $??ID??6-   
 69   ?? $ ID??? 58      $??Наименование??6-   
 6C   ?? $ NameOfProduct??? 59      $??Цена за кг??6-   
 6A   ?? $ PricePerKilogram??? 5:      $??Всего кг??6-   
 6?   ?? $ TotalKilogram??? 5;      $??Тип рыбы??6-   
 6?   ?? $ FishType??? 5<      $??Живая\Неживая??6-   
 6D   ?? $ FishCondition?5=      5?      5@      ?? 5A      -   5        $??DairyTab??5A      ??5B      ?? 5C      $'??!Молочные продукты??6     5E      ?? 5F      .@?5G      m? $$??Зарезервировать??6#    6<   ?? *OpenReserveProductWnd+5H      .??5J      ?? -   5        $ ViewAllDairies??5J      ??63   ?? *	Dairies+ 6S   ?? *SelectedDairy+	 5K      ?? 5L      .P?5M      ?? $??ID??6-   
 69   ?? $ ID??? 5N      $??Наименование??6-   
 6C   ?? $ NameOfProduct??? 5O      $??Цена за кг??6-   
 6A   ?? $ PricePerKilogram??? 5P      $??Всего кг??6-   
 6?   ?? $ TotalKilogram??? 5Q      $"??Кол-во упаковок??6-   
 6F   ?? $ NumberOfPackages??? 5R      $$??Цена за упаковку??6-   
 6G   ?? $ PricePerPack?5S      5U      5V      ?? 5W      -   5        $??FruitTab??5W      ??5X      ?? 5Y      $??Фрукты??6     5[      ?? 5\      .@?5]      m? $$??Зарезервировать??6#    6<   ?? *OpenReserveProductWnd+5^      .??5`      ?? -	   5        $ ViewAllFruit??5`      ??61   ?? *Fruit+ 6O   ?? *SelectedFruit+	 5a      ?? 5b      .P?5c      ?? $??ID??6-   
 69   ?? $ ID??? 5d      $??Наименование??6-   
 6C   ?? $ NameOfProduct??? 5e      $??Цена за кг??6-   
 6A   ?? $ PricePerKilogram??? 5f      $??Всего кг??6-   
 6?   ?? $ TotalKilogram??? 5g      $??Месяц сбора??6-   
 6B   ?? $ CollectionDay??? 5h      $??День сбора??6-   
 6A   ?? $ CollectionMonth?5i      5k      5l      ?? 5m      -
   5        $??VegetablesTab??5m      ??5n      ?? 5o      $??
Овощи??6     5q      ?? 5r      .@?5s      m? $$??Зарезервировать??6#    6<   ?? *OpenReserveProductWnd+5t      .??5v      ?? -   5        $ ViewAllVegetables??5v      ??66   ?? *
Vegetables+ 6Y   ?? *SelectedVegetables+	 5w      ?? 5x      .P?5y      ?? $??ID??6-   
 69   ?? $ ID??? 5z      $??Наименование??6-   
 6C   ?? $ NameOfProduct??? 5{      $??Цена за кг??6-   
 6A   ?? $ PricePerKilogram??? 5|      $??Всего кг??6-   
 6?   ?? $ TotalKilogram??? 5}      $??Месяц сбора??6-   
 6B   ?? $ CollectionDay??? 5~      $??День сбора??6-   
 6A   ?? $ CollectionMonth?5      5?      5?      5?      ?? 5?   
   $??1??6    ?? Orientation$ 
Horizontal=?6"   $??Center=?6;   .+?5?      ?? $??Мои заказы??6   $??0 0 5 0q?6?   ??6*   ?? *OpenOrdersWindow+??6O   ??  ?? ElementName$ ClientInterfaceWnd??6?   5?      ?? 5?   
   $??1??6   $ 
Horizontal=?6"   $
??Left=?6;   .+?5?      ?? $??
Выход??6   $??0 0 5 0q?6?   ??6%   ?? *CloseUserInterface+??6L   ?? $ ClientInterfaceWnd??6?   5?      5?      5?      