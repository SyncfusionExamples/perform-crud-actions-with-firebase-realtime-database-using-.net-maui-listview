# perform-crud-actions-with-firebase-realtime-database-using-.net-maui-listview

This demo explains about how to perform CRUD operations with Firebase Realtime database using.NET MAUI ListView (SfListView).

## Sample

```xaml
<syncfusion:SfListView
                x:Name="listView"
                ItemSize="60"
                ItemsSource="{Binding Contacts}"
                TapCommand="{Binding EditContactCommand}">
    <syncfusion:SfListView.ItemTemplate>
        <DataTemplate>
            <Grid
                x:Name="grid"
                RowDefinitions="*,1"
                RowSpacing="0">
                <Grid ColumnDefinitions="70,*,auto">
                    <Image
                        HeightRequest="50"
                        HorizontalOptions="Center"
                        Source="{Binding ContactImage}"
                        VerticalOptions="Center"
                        WidthRequest="50" />
                    <Grid
                        Grid.Column="1"
                        Padding="10,0,0,0"
                        RowDefinitions="*,*"
                        RowSpacing="1"
                        VerticalOptions="Center">

                        <Label
                            FontSize="{OnPlatform Android={OnIdiom Phone=16,
                                                                    Tablet=18},
                                                    iOS={OnIdiom Phone=16,
                                                                Tablet=18},
                                                    MacCatalyst=18,
                                                    WinUI={OnIdiom Phone=18,
                                                                    Tablet=20,
                                                                    Desktop=20}}"
                            LineBreakMode="NoWrap"
                            Text="{Binding ContactName}"
                            TextColor="#474747" />
                        <Label
                            Grid.Row="1"
                            Grid.Column="0"
                            FontSize="{OnPlatform Android={OnIdiom Phone=12,
                                                                    Tablet=14},
                                                    iOS={OnIdiom Phone=12,
                                                                Tablet=14},
                                                    MacCatalyst=14,
                                                    WinUI={OnIdiom Phone=12,
                                                                    Tablet=12,
                                                                    Desktop=12}}"
                            LineBreakMode="NoWrap"
                            Text="{Binding ContactNumber}"
                            TextColor="#474747" />
                    </Grid>
                </Grid>
                <Border
                    Grid.Row="1"
                    BackgroundColor="#E4E4E4"
                    HeightRequest="1" />
            </Grid>
        </DataTemplate>
    </syncfusion:SfListView.ItemTemplate>
</syncfusion:SfListView>

<ImageButton
    Margin="20"
    Background="{StaticResource Primary}"
    Command="{Binding CreateNewContactCommand}"
    CornerRadius="20"
    HeightRequest="40"
    HorizontalOptions="End"
    Source="add.png"
    VerticalOptions="End"
    WidthRequest="40" />
```

## Requirements to run the demo

* [Visual Studio 2017](https://visualstudio.microsoft.com/downloads/) or [Visual Studio for Mac](https://visualstudio.microsoft.com/vs/mac/)
* Xamarin add-ons for Visual Studio (available via the Visual Studio installer).

## Troubleshooting

### Path too long exception

If you are facing path too long exception when building this example project, close Visual Studio and rename the repository to short and build the project.

