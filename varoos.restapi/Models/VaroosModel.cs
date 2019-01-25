using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace varoos.restapi.Models
{
    public abstract class Observation
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public DateTime Date { get; set; }
    }
    public class Report : Observation
    {
        public List<Variable> VariableList { get; set; }
        public string Description { get; set; }

    }
    public class Phenomena : Observation
    {
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
    }
    public class Cloudiness : Observation
    {
        public List<Cloud> CloudList { get; set; }
    }

    public class Cloud
    {
        public int Extent { get; set; }
        public int Height { get; set; }
        public string Genera { get; set; }
        public List<SelectableValue> SpecieCollection { get; set; }
        public List<SelectableValue> VarietyCollection { get; set; }
        public List<SelectableValue> GenitusCollection { get; set; }
        public List<SelectableValue> SupplementaryFeatureCollection { get; set; }
        public List<SelectableValue> AccessoryCloudCollection { get; set; }
        public List<SelectableValue> MutatusCollection { get; set; }
    }
    public class SelectableValue
    {
        public string Value { get; set; }
        public bool IsSelected { get; set; }
    }

    #region Person
    public enum PersonPosition
    {
        Observador, Jefe, Revisor
    }
    public class Person
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public PersonPosition Position { get; set; }
        //public IEnumerable<TimeInterval> WorkingTime { get; set; }
        //public Station Station { get; set; }
    }
    #endregion

    #region Instrument
    public class Instrument
    {
        public string Id { get; set; }
        public string Name { get; set; }
        public IEnumerable<TimeInterval> Operational { get; set; }
        public IEnumerable<InstrumentOutput> Outputs { get; set; }
        public Station Station { get; set; }
    }
    public class InstrumentOutput
    {
        public string VariableId { get; set; }
        public string Unit { get; set; }
        public Dictionary<TimeInterval, NumericPair> Correction { get; set; }


    }
    public class TimeInterval
    {
        public DateTime Start { get; set; }
        public DateTime End { get; set; }
    }
    public class NumericPair
    {
        public double A { get; set; }
        public double B { get; set; }
    }
    #endregion

    #region Location
    public abstract class Location
    {
        public double Latitude { get; set; }
        public double Longitude { get; set; }
        /// <summary>
        /// Altura con respecto al nivel medio del mar
        /// </summary>
        public double Height { get; set; }
    }
    public class Station : Location
    {
        public string Name { get; set; }
        public string Id { get; set; }
    }
    #endregion

    #region Variable
    public abstract class Variable
    {
        public string Id { get; set; }
        public string Magnitude { get; set; }
        public DateTime Time { get; set; }
        public string Value { get; set; }

    }
    public class SelectableTextVariable : Variable
    {
        public IEnumerable<string> ValuesUniverse { get; set; }
    }
    public class NumericVariable : Variable
    {
        public double CorrectedValue { get; set; }
        public string Unit { get; set; }
    }
    public class SelectableBoolVariable : Variable
    {
        public bool BooleanValue { get; set; }
    }
    #endregion

}