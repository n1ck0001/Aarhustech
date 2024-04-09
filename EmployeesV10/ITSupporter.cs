
using EmployeesV10;

public class ITSupporter : Employee
{
    #region Properties
   
    public string PrimaryWorkArea { get; set; }

   
    #endregion

    #region Constructor
    public ITSupporter(string name, int hoursPerWeek, string primaryWorkArea)
    {
        Name = name;
        HoursPerWeek = hoursPerWeek;
        PrimaryWorkArea = primaryWorkArea;
        GetAllInformation = $"IT-Supporter {Name} works {HoursPerWeek} hours/week, mostly with {PrimaryWorkArea}";
    }
    #endregion
}