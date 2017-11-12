﻿using EventManagement.Events;
using EventManagement.ValueObjects;
using Newtonsoft.Json;
using Shared;
using System;

namespace EventManagement.Entities
{
    public interface IProvideEntitySnapshot<TSnapshot>
    {
        TSnapshot Snapshot();
    }
    public class ConcertSnapshot
    {
        public string Id { get; set; }
        public DateTime Date { get; set; }
        public string Organizer { get; set; }
        public string Description { get; set; }
        public string TitleGeo { get; set; }
        public string TitleEng { get; set; }
        public ConcertSnapshot(DateTime date, string organizer, string description, string titleGeo, string titleEng)
        {
            Date = date;
            Description = description;
            Organizer = organizer;
            TitleGeo = titleGeo;
            TitleEng = titleEng;
        }

        public static ConcertSnapshot CreateFrom(Concert concert)
        {
            IProvideEntitySnapshot<ConcertSnapshot> snapshotProvider = concert;
            var concertSnapshot = snapshotProvider.Snapshot();
            return concertSnapshot;
        }
    }

    public class Company
    {
        public int Id { get; set; }
        public string Name { get; set; }
    }

    public class Concert : AggregateRoot, IProvideEntitySnapshot<ConcertSnapshot>
    {
        private EventDescription EventDescription { get; set; }
        private EventTitleSummary EventTitle { get; set; }
        private string Organizer { get; set; }
        public int CompanynId { get; set; }

        private Concert() : base()
        {

        }

        public Concert(EventId id,
            EventTitleSummary eventTitle,
            EventDescription eventDescription)
        {
            Id = id ?? throw new ArgumentNullException(nameof(id));
            EventDescription = eventDescription ?? throw new ArgumentNullException(nameof(eventDescription));
            EventTitle = eventTitle ?? throw new ArgumentNullException(nameof(eventTitle));
        }

        [JsonConstructor]
        private Concert(EventId id,
            EventTitleSummary eventTitle,
            EventDescription eventDescription,
            string organizer) :
            this(id, eventTitle, eventDescription)
        {
            Organizer = organizer;
        }

        public static Concert CreateFrom(ConcertSnapshot snapshot)
        {
            return new Concert(new EventId(snapshot.Id),
                new EventTitleSummary(new GeoTitle(snapshot.TitleGeo)),
                new EventDescription(snapshot.Date, snapshot.Description)
                );
        }

        public void AssignOrganizer(string organizer)
        {
            if (string.IsNullOrEmpty(organizer))
            {
                throw new ArgumentException(nameof(organizer));
            }

            Organizer = organizer;
        }

        public void ChangeConcertTitle(EventTitleSummary newTitle)
        {
            EventTitle = newTitle;
        }

        ConcertSnapshot IProvideEntitySnapshot<ConcertSnapshot>.Snapshot()
        {
            return new ConcertSnapshot(DateTime.Now, null, null, null, null);
        }
    }
}
