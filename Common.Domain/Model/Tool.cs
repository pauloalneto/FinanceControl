using Common.Domain.Enums;
using System;

namespace Common.Domain.Model
{
    public class Tool
    {

        public Tool()
        {
            this.CanReadAll = true;
            this.CanDelete = true;
            this.CanEdit = true;
            this.CanSave = true;
            this.CanReadOne = true;
            this.CanReadCustom = true;
            this.CanReadDataItem = true;
        }

        public string Name { get; set; }
        public string Icon { get; set; }
        public string Route { get; set; }
        public string Key { get; set; }
        public string ParentKey { get; set; }
        public ETypeTools Type { get; set; }

        public Boolean CanReadDataItem { get; set; }
        public Boolean CanReadOne { get; set; }
        public Boolean CanReadCustom { get; set; }
        public Boolean CanReadAll { get; set; }
        public Boolean CanDelete { get; set; }
        public Boolean CanEdit { get; set; }
        public Boolean CanSave { get; set; }

        public bool CanWrite { get => this.CanEdit && this.CanSave; }


    }


}
