using System;
public class dbo_DimScenarioClass
{
    private Int32 m_ScenarioKey;
    private String m_ScenarioName;

    public dbo_DimScenarioClass() { }

    public Int32 ScenarioKey
    {
        get
        {
            return m_ScenarioKey;
        }
        set
        {
            m_ScenarioKey = value;
        }
    }
    public String ScenarioName
    {
        get
        {
            return m_ScenarioName;
        }
        set
        {
            m_ScenarioName = value;
        }
    }

}

 
