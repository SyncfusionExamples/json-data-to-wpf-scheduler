using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Windows.Media;

namespace WpfScheduler
{
    public class SchedulerViewModel
    {
        public ObservableCollection<Meeting> Meetings { get; set; }

        private string JsonData =
            "[{\"Subject\": \"General Meeting\",\"StartTime\": \"30-11-2020 15:00:00\",\"EndTime\":\"30-11-2020 16:00:00\",\"Background\":\"#5944dd\", \"IsAllDay\":\"True\"}, " +
            "{\"Subject\": \"Plan Execution\",\"StartTime\": \"22-11-2020 10:00:00\",\"EndTime\":\"22-11-2020 11:00:00\",\"Background\":\"#ff0000\", \"IsAllDay\":\"False\"}," +
            "{\"Subject\": \"Performance Check\",\"StartTime\": \"17-11-2020 17:00:00\",\"EndTime\":\"17-11-2020 18:00:00\",\"Background\":\"#5944dd\", \"IsAllDay\":\"False\"}," +
            "{\"Subject\": \"Consulting\",\"StartTime\": \"03-11-2020 9:00:00\",\"EndTime\":\"03-11-2020 11:00:00\",\"Background\":\"#ed0497\", \"IsAllDay\":\"True\"}," +
            "{\"Subject\": \"Yoga Therapy\",\"StartTime\": \"27-11-2020 10:00:00\",\"EndTime\":\"27-11-2020 11:00:00\",\"Background\":\"#ff0000\", \"IsAllDay\":\"False\"}," +
            "{\"Subject\": \"Project Plan\",\"StartTime\": \"30-11-2020 15:00:00\",\"EndTime\":\"30-11-2020 16:00:00\",\"Background\":\"#ed0497\", \"IsAllDay\":\"False\"} ]";
        public SchedulerViewModel()
        {
            Meetings = new ObservableCollection<Meeting>();

            List<JSONData> jsonDataCollection = JsonConvert.DeserializeObject<List<JSONData>>(JsonData);

            foreach (var data in jsonDataCollection)
            {
                Meetings.Add(new Meeting()
                {
                    EventName = data.Subject,
                    From = DateTime.Parse(data.StartTime),
                    To = DateTime.Parse(data.EndTime),
                    color = new SolidColorBrush((Color)ColorConverter.ConvertFromString(data.Background)),
                    AllDay = Convert.ToBoolean(data.IsAllDay)
                });
            }
        }
    }
}
            
        
    


