   M S B A M L   `   `   `  ????K  GProductWarehouse, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null?$clr-namespace:ProductWarehouse.ViewsProductWarehouse.Views  5   	   I)clr-namespace:ProductWarehouse.ViewModelsProductWarehouse.ViewModels  6<   )    #ProductWarehouse.Views.OrdersWindow   5   	   \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   6local$clr-namespace:ProductWarehouse.Views     5   	   ?	viewModel)clr-namespace:ProductWarehouse.ViewModels     6<   -   5        $??	OrdersWnd??5	   	     ? Title$  OrdersWindow??5   	   $	??600??6   $	??900??6+    ? 	Resources 5
      ,   &ProductWarehouse.ViewModels.DataManage   viewModelSourse??%   &	          5   
   6   5       ? DataContext 5      ?? 5   
    ?? Source# [  6   .??5      ?  ? RowDefinitions 5   
   ?? 5      $??* ?6   ?? 5      $??50 ?6   .+?5   
   ?? $??0??6   .@?5      ?? -   5        $??ReservedProductTab??5      ??5      ?? 5      $??Мои заказы??6     ? ContextMenu 5      ?? 5      .@?5      m? $`??ZЗаказ был получен/Уведомлен об отмене резервации??6#    m? Command 6]   ?? *DeleteReservation+5      .??5      ?? -   5         ??Name$" ViewAllReservationProductsID??5      ??6A   ?? *ReservationProductsID+ ?? SelectedItem 6o   ?? *SelectedReservationProduct+	 ?? View	 5       ?? 5!      .P?5"      ?? $/??)Наименование продукта??6-   
 ?? DisplayMemberBinding
 6L   ??  ?? Path$
 Name??? 5#      $+??%Зарезервированно кг??6-   
 6J   ?? $ Weight??? 5$      $??Статус заказа??6-   
 6D   ?? $ 	Condition?5%      5'      5(      5)      ?? 5+   
   $??1??6    ?? Orientation$ 
Horizontal=?6"   $
??Left=?6;   .+?5,      ?? $??
Назад??6   $??0 0 5 0q?6y   ??6%   ?? *ClientToBack+??6F   ??  ?? ElementName$ 	OrdersWnd??6y   5-      5.      5/      