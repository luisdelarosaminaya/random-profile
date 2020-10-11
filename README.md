# Random profile

Desktop application with WPF and Material Design.
\
\
Random profile generator. Desktop application built with Windows Presentation Foundation: in this project you can see the mechanism (:blue_heart:) of data binding in WPF, and the integration with Material Design.

## PropertyChanged.Fody :confetti_ball:

[PropertyChanged.Fody](https://github.com/Fody/PropertyChanged) Injects INotifyPropertyChanged code into properties at compile time. It makes <code>TwoWay</code> binding practically invisible and extremely simple.

Before [PropertyChanged.Fody](https://github.com/Fody/PropertyChanged) implementation:

```csharp
public class Person : INotifyPropertyChanged
{
    private string _name;

    public string Name
    {
        get { return _name; }
        set
        {
            if (value != _name)
            {
                _name = value;
                OnPropertyChanged();
            }
        }
    }
    
    public event PropertyChangedEventHandler PropertyChanged;

    protected void OnPropertyChanged([CallerMemberName] string propertyName = "")
    {
        PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
    }
}
```
After [PropertyChanged.Fody](https://github.com/Fody/PropertyChanged) implementation:

```csharp
public class Person : INotifyPropertyChanged
{    
    public string Name { get; set; }

    public event PropertyChangedEventHandler PropertyChanged;
}
```
## Technologies 🛠️

Project is created with:

* [PropertyChanged.Fody](https://github.com/Fody/PropertyChanged) version: 3.2.9
* [Newtonsoft.Json](https://github.com/JamesNK/Newtonsoft.Json) version: 12.0.3
* [MaterialDesignThemes](https://github.com/MaterialDesignInXAML/MaterialDesignInXamlToolkit) version: 3.1.3
* [AutoMapper](https://github.com/AutoMapper/AutoMapper) version: 10.0.0

## Screenshots :camera:

![Random profiles](https://github.com/luisdelarosaminaya/random-profile/blob/dev/RandomProfile/Image-demo/screen-image.gif)
