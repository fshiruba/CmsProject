using System;
using System.Collections.Generic;
using EPiServer.Shell.ObjectEditing;
using EPiServer.Shell.ObjectEditing.EditorDescriptors;

namespace CmsProject.Models.BaseTypes
{
    [EditorDescriptorRegistration(TargetType = typeof(string), UIHint = "ColorPicker")]
    public class ColorPickerEditorDescriptor : EditorDescriptor
    {
        public ColorPickerEditorDescriptor()
        {
            ClientEditingClass = _editingClient;
        }

        private const string _editingClient = "shiruba/ColorPicker";

        public override void ModifyMetadata(ExtendedMetadata metadata, IEnumerable<Attribute> attributes)
        {
            ClientEditingClass = _editingClient;
            base.ModifyMetadata(metadata, attributes);
        }
    }
}