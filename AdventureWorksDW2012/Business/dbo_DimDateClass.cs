using System;
public class dbo_DimDateClass
{
    private Int32 m_DateKey;
    private DateTime m_FullDateAlternateKey;
    private Byte m_DayNumberOfWeek;
    private String m_EnglishDayNameOfWeek;
    private String m_SpanishDayNameOfWeek;
    private String m_FrenchDayNameOfWeek;
    private Byte m_DayNumberOfMonth;
    private Int16 m_DayNumberOfYear;
    private Byte m_WeekNumberOfYear;
    private String m_EnglishMonthName;
    private String m_SpanishMonthName;
    private String m_FrenchMonthName;
    private Byte m_MonthNumberOfYear;
    private Byte m_CalendarQuarter;
    private Int16 m_CalendarYear;
    private Byte m_CalendarSemester;
    private Byte m_FiscalQuarter;
    private Int16 m_FiscalYear;
    private Byte m_FiscalSemester;

    public dbo_DimDateClass() { }

    public Int32 DateKey
    {
        get
        {
            return m_DateKey;
        }
        set
        {
            m_DateKey = value;
        }
    }
    public DateTime FullDateAlternateKey
    {
        get
        {
            return m_FullDateAlternateKey;
        }
        set
        {
            m_FullDateAlternateKey = value;
        }
    }
    public Byte DayNumberOfWeek
    {
        get
        {
            return m_DayNumberOfWeek;
        }
        set
        {
            m_DayNumberOfWeek = value;
        }
    }
    public String EnglishDayNameOfWeek
    {
        get
        {
            return m_EnglishDayNameOfWeek;
        }
        set
        {
            m_EnglishDayNameOfWeek = value;
        }
    }
    public String SpanishDayNameOfWeek
    {
        get
        {
            return m_SpanishDayNameOfWeek;
        }
        set
        {
            m_SpanishDayNameOfWeek = value;
        }
    }
    public String FrenchDayNameOfWeek
    {
        get
        {
            return m_FrenchDayNameOfWeek;
        }
        set
        {
            m_FrenchDayNameOfWeek = value;
        }
    }
    public Byte DayNumberOfMonth
    {
        get
        {
            return m_DayNumberOfMonth;
        }
        set
        {
            m_DayNumberOfMonth = value;
        }
    }
    public Int16 DayNumberOfYear
    {
        get
        {
            return m_DayNumberOfYear;
        }
        set
        {
            m_DayNumberOfYear = value;
        }
    }
    public Byte WeekNumberOfYear
    {
        get
        {
            return m_WeekNumberOfYear;
        }
        set
        {
            m_WeekNumberOfYear = value;
        }
    }
    public String EnglishMonthName
    {
        get
        {
            return m_EnglishMonthName;
        }
        set
        {
            m_EnglishMonthName = value;
        }
    }
    public String SpanishMonthName
    {
        get
        {
            return m_SpanishMonthName;
        }
        set
        {
            m_SpanishMonthName = value;
        }
    }
    public String FrenchMonthName
    {
        get
        {
            return m_FrenchMonthName;
        }
        set
        {
            m_FrenchMonthName = value;
        }
    }
    public Byte MonthNumberOfYear
    {
        get
        {
            return m_MonthNumberOfYear;
        }
        set
        {
            m_MonthNumberOfYear = value;
        }
    }
    public Byte CalendarQuarter
    {
        get
        {
            return m_CalendarQuarter;
        }
        set
        {
            m_CalendarQuarter = value;
        }
    }
    public Int16 CalendarYear
    {
        get
        {
            return m_CalendarYear;
        }
        set
        {
            m_CalendarYear = value;
        }
    }
    public Byte CalendarSemester
    {
        get
        {
            return m_CalendarSemester;
        }
        set
        {
            m_CalendarSemester = value;
        }
    }
    public Byte FiscalQuarter
    {
        get
        {
            return m_FiscalQuarter;
        }
        set
        {
            m_FiscalQuarter = value;
        }
    }
    public Int16 FiscalYear
    {
        get
        {
            return m_FiscalYear;
        }
        set
        {
            m_FiscalYear = value;
        }
    }
    public Byte FiscalSemester
    {
        get
        {
            return m_FiscalSemester;
        }
        set
        {
            m_FiscalSemester = value;
        }
    }
}

 
