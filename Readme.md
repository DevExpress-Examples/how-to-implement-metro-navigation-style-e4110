# How to implement Metro Navigation Style


<p><strong>This example is actually only for versions 12.2 and lower. In 13.1, we introduced the </strong><a href="https://documentation.devexpress.com/#WPF/clsDevExpressXpfWindowsUINavigationFrametopic"><strong>NavigationFrame</strong></a><strong> control, providing a similar functionality out of the box. See </strong><a href="https://www.devexpress.com/Support/Center/p/E4663"><strong>How To: Use NavigationButtons to Navigate in WPF WindowsUI Applications</strong></a><strong> for more information.</strong></p>
<p><br />With version v12.1.5, a new namespace is available in our DevExpress.Xpf.Core.Extensions library. This namespace is DevExpress.Xpf.Core.MvvmSample. Using this namespace it is possible to create the Metro Navigation style. Refer to the DevExpress.Xpf.Core.Extensions library in your project and add the DevExpress.Xpf.Core.MvvmSample namespace (dxmvvm="<a href="http://schemas.devexpress.com/winfx/2008/xaml/mvvmsample">http://schemas.devexpress.com/winfx/2008/xaml/mvvmsample</a>", for xaml) to the using section of necessary files.</p>
<p>The first major step here is to represent a custom UserControl in a format that can be used by our <strong>MvvmRoot</strong> component. The MvvmRoot component allows you to register custom views and provide metro navigation between them.<strong> MvvmRoot</strong> is a wrapper around the whole Metro Navigation system. This component needs to be added to the MainWindow, and custom views should be registered in <strong>MvvmRoot</strong>.</p>
<p>Here are steps required to convert custom UserControls to custom views applicable for <strong>MvvmRoot</strong>. The main idea is to separate the UserControl data from your UserControl representation:</p>
<p><strong>1</strong>. Inherit your custom UserControl from the <strong>ModuleView </strong>class. The ModuleView class is a UserControl descendant that supports our special IView interface. The ModuleView descendant will be your data representation.</p>
<p><strong>2</strong>. Create a <strong>Module</strong> class descendant. Get data for your custom view in this Module descendant. The Module class instance will serve as DataContext for your custom view. In your custom view xaml, bind to data properties you specify in the Module descendant.</p>
<p><strong>3</strong>. Now you have two modules. Register them in our <strong>MvvmRoot</strong> component. In the MainWindow, the following line is responsible for registration:</p>


```xaml
<br>
<dxmvvm:ModuleDescription ModuleType="{x:Type viewmodel:Main}" ViewType="{x:Type view:MainView}" />
```


<br />
<p>Using these three steps, you can convert any number of user controls to custom views.</p>
<p>It is necessary to create the main view (with <strong>TileLayoutControl </strong>as representation) in a manner similar to the one you use to create your custom views. The only difference is that the main module part should be inherited from the <strong>MainModule </strong>class, not <strong>Module</strong>. In the <strong>MainModule </strong>descendant, declare a command to navigate via custom views. These commands will be available in the <strong>MainView </strong>representation, and you can assign them to the <strong>Tile.Command </strong>property:</p>


```xaml
<br>
<dxlc:Tile Style="{StaticResource VerticalTile}" Header="User Management" Background="#FF00ABDC" Command="{Binding ShowFirstViewCommand}" >...</dxlc:Tile>
```


<br />


```cs
    public class Main : MainModule {
        #region Commands
        protected override void InitializeCommands() {
            base.InitializeCommands();
            ShowMainCommand = new SimpleActionCommand(DoShowModule<MainData>);
            ShowFirstViewCommand = new SimpleActionCommand(DoShowModule<FirstData>);
            //....
        }
        public ICommand ShowMainCommand { get; private set; }
        public ICommand ShowFirstViewCommand { get; private set; }
        //...
        void DoShowModule<T>(object p) where T : ModuleData, new() { ShowModule<T>(p); }
        #endregion
    }




```


<p>The ViewPresenter class with DoubleAnimation is used to provide smooth replacement of one view with another one.</p>

<br/>


