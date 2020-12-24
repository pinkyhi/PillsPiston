﻿using PillsPiston.Core.Enums;
using PillsPiston.DAL.Entities.BaseEntities;

namespace PillsPiston.DAL.Entities
{
    public class Relationship : BaseDto
    {
        public string WatcherId { get; set; }

        public User Watcher { get; set; }

        public string SubjectId { get; set; }

        public User Subject { get; set; }

        public RelationshipStatusesEnum RelationshipStatus { get; set; }
    }
}
