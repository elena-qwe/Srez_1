using System.Collections.ObjectModel;
using System.Linq;
using Avalonia.Controls;
using Avalonia.Interactivity;
using Avalonia.ReactiveUI;
using Microsoft.EntityFrameworkCore;
using Srez_1.Models;

namespace Srez_1;

public partial class MainWindow : Window
{
    public MainWindow()
    {
        InitializeComponent();
        Load();
    }

    private void Load()
    {
        using (Gr601MaevlContext db = new Gr601MaevlContext())
        {
            MyUser_DataGrid.Items = db.TableUsers.Include(r=> r.IdRoleNavigation).ToList();
            //Role_DataGrid.Items = db.Rolenames.ToList();
        }
        
        //Role_DataGrid.Items = db.Rolenames.ToList();
    }

    
}