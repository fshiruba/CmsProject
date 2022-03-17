using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Diagnostics;
using System.Linq;
using EPiServer.Shell.ObjectEditing;

namespace CmsProject.Models.BaseTypes
{
    public class FromRangeSelectionFactory : ISelectionFactory
    {
        public IEnumerable<ISelectItem> FromMetadata(int min, int max, Type modelType)
        {
            var list = new List<ISelectItem>();

            for (int i = min; i < (max + 1); i++)
            {
                var value = Convert.ChangeType(i, modelType);

                list.Add(new SelectItem() { Text = i.ToString(), Value = value });
            }

            return list;
        }

        public IEnumerable<ISelectItem> GetSelections(ExtendedMetadata metadata)
        {
            try
            {
                if (metadata.Attributes.Any(x => x is RangeAttribute))
                {
                    RangeAttribute att = metadata.Attributes.FirstOrDefault(x => x is RangeAttribute) as RangeAttribute;

                    return FromMetadata((int)att.Minimum, (int)att.Maximum, metadata.ModelType);
                }
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex);
            }

            return Array.Empty<ISelectItem>();

            //return new ISelectItem[]
            //{
            //    new SelectItem() { Text = "01", Value = 1 },
            //    new SelectItem() { Text = "02", Value = 2 },
            //    new SelectItem() { Text = "03", Value = 3 },
            //    new SelectItem() { Text = "04", Value = 4 },
            //    new SelectItem() { Text = "05", Value = 5 },
            //    new SelectItem() { Text = "06", Value = 6 },
            //    new SelectItem() { Text = "07", Value = 7 },
            //    new SelectItem() { Text = "08", Value = 8 },
            //    new SelectItem() { Text = "09", Value = 9 },
            //    new SelectItem() { Text = "10", Value = 10 }
            //};
        }
    }
}