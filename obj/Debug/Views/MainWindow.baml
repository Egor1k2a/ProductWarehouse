   M S B A M L   `   `   `  ????K  GProductWarehouse, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null?$clr-namespace:ProductWarehouse.ViewsProductWarehouse.Views  5   	   I)clr-namespace:ProductWarehouse.ViewModelsProductWarehouse.ViewModels  5   R   '    !ProductWarehouse.Views.MainWindow   5   	   \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   6local$clr-namespace:ProductWarehouse.Views     5   	   _ [MaterialDesignThemes.Wpf, Version=4.6.1.0, Culture=neutral, PublicKeyToken=df2a72020bd7962aFmaterialDesign1http://materialdesigninxaml.net/winfx/xaml/themes  5   	   9	viewModel)clr-namespace:ProductWarehouse.ViewModels  6R   -   5        $??MainWnd??5
   	     ? Title$  Информация??5	   	   $	??600??6   $	??800??6)    ? WindowStyle$ ThreeDBorderWindow=?65    ? 	Resources 5      3   -ProductWarehouse.ViewModels.UsersDataManageVM   viewModelSourse??%   &	          5   
   6&   5       ? DataContext 5      ?? 5   
    ?? Source# [  6   .??5      ? ???	#ffdadada.+?5   
   ?? $	??400??6   $??15q?6    
???????$??Center=?6?    ?? Padding$ 30q?6Z   $	??550??6g    ?? CornerRadius$ 20??6v    J? Effect 5      3  -System.Windows.Media.Effects.DropShadowEffect  5         
BlurRadius$ 30Q?6#   	   Color$	 	LightGray??63   
   ShadowDepth$
 0Q?6E   ._?5      ?? .+?5      ?? $??Здравствуйте!??6   $??30(?61   $
??Bold"?6?   $??0 0 0 20q?6Q   ?? 5      $[??UДанная программа помогает Вам, нашим клиентам,??6   $??15(?6R   $
??Bold"?6`   $??0 0 0 3q?6r   ?? 5      $m??gзарезервировать в удобное для Вас время нужные продукты??6   $??15(?6[   $
??Bold"?6i   $??0 0 0 3q?6{   ?? 5      $l??fпитания и не переживать, что в ваше отсутствие они могут??6   $??15(?6\   $
??Bold"?6j   $??0 0 0 3q?6|   ?? 5      $7??1быть куплены кем-то другим.??6   $??15(?6?   $
??Bold"?6M   $??0 0 0 20q?6_   ?? 5      $??Продолжить??6   $
??0 20q?6.   ??6<   ?? *OpenInputWnd+??6]   ??  ?? ElementName$ MainWnd??5       5!      5"      5#      