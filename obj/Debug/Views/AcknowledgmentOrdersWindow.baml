   M S B A M L   `   `   `  ????K  GProductWarehouse, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null?$clr-namespace:ProductWarehouse.ViewsProductWarehouse.Views  5   	   I)clr-namespace:ProductWarehouse.ViewModelsProductWarehouse.ViewModels  6<   7    1ProductWarehouse.Views.AcknowledgmentOrdersWindow   5   	   \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   6local$clr-namespace:ProductWarehouse.Views     5   	   ?	viewModel)clr-namespace:ProductWarehouse.ViewModels     6<   -   5        $??AcknowledgmentOrdersWnd??5	   	     ? Title$   AcknowledgmentOrdersWindow??5   	   $	??600??6,   $
??1030??69    ? 	Resources 5
      ,   &ProductWarehouse.ViewModels.DataManage   viewModelSourse??%   &	          5   
   6   5       ? DataContext 5      ?? 5   
    ?? Source# [  6   .??5      ?  ? RowDefinitions 5   
   ?? 5      $??* ?6   ?? 5      $??50 ?6   .+?5   
   ?? $??0??6   .@?5      ?? -   5        $??ReservedProductTab??5      ??5      ?? 5      $Q??KПодтверждение или отклонение резервации??6     ? ContextMenu 5      ?? 5      .@?5      m? $??Принять??6#    m? Command 64   ?? *AcknowledgeProduct+m? 5      $??Отклонить??6#    66   ?? *RefuseProduct+5      .??5       ?? -   5         ??Name$  ViewAllReservationProducts??5       ??6?   ?? *ReservationProductsAll+ ?? SelectedItem 6n   ?? *SelectedReservationProduct+	 ?? View	 5!      ?? 5"      .P?5#      ?? $??ID клиента??6-   
 ?? DisplayMemberBinding
 6A   ??  ?? Path$ 
IDOfClient??? 5$      $/??)Наименование продукта??6-   
 6L   ?? $
 Name??? 5%      $+??%Зарезервированно кг??6-   
 6J   ?? $ Weight??? 5&      $??Статус заказа??6-   
 6D   ?? $ 	Condition?5'      5)      5*      5+      ?? 5,   
   $??1??6    ?? Orientation$ 
Horizontal=?6"   $
??Left=?6;   .+?5-      ?? $??
Назад??6   $??0 0 5 0q?6?   ??6%   ?? *OpenEmployeeToBackInterface+??6U   ??  ?? ElementName$ AcknowledgmentOrdersWnd??6?   5.      5/      50      