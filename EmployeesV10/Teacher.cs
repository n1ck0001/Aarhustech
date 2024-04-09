
using EmployeesV10;

public class Teacher : Employee
{
    #region Properties

    public int PayGrade { get; set; }


    #endregion

    #region Constructor
    public Teacher(string name, int hoursPerWeek, int payGrade)
    {
        Name = name;
        HoursPerWeek = hoursPerWeek;
        PayGrade = payGrade;
        GetAllInformation = $"Teacher {Name} works {HoursPerWeek} hours/week, at paygrade {PayGrade}";
    }
    #endregion
}