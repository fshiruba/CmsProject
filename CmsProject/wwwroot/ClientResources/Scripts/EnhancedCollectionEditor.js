define([
    "dojo/_base/array",
    "dojo/_base/declare",
    "dojo/_base/lang",
    "dojo/DeferredList",
    "epi-cms/contentediting/editors/CollectionEditor",
    "/ClientResources/Scripts/EnhancedFormatters.js"
],
    function (
        array,
        declare,
        lang,
        DeferredList,
        CollectionEditor,
        enhancedFormatters
    ) {
        return declare([CollectionEditor], {
            _getGridDefinition: function () {
                var result = this.inherited(arguments);

                enhancedFormatters.setItemMappings(this.itemMappings);

                for (var i = 0; i < this.fields.length; i++) {
                    if (this.fields[i].isImage) {
                        result[this.fields[i].name].formatter = enhancedFormatters.imageFormatter;
                    } else {
                        result[this.fields[i].name].formatter = enhancedFormatters.urlFormatter;
                    }
                }

                return result;
            },

            onExecuteDialog: function () {
                var item = this._itemEditor.get("value");

                var items = [];

                for (var i = 0; i < this.fields.length; i++) {
                    var value = item[this.fields[i].name];

                    if (!value) {
                        continue;
                    }

                    if (isNaN(value)) {
                        items.push(enhancedFormatters.getItemByPermanentLink(value));
                    } else {
                        items.push(enhancedFormatters.getItemByContentLink(value));
                    }
                }

                var dl = new DeferredList(items);

                dl.then(lang.hitch(this, function () {
                    if (this._editingItemIndex !== undefined) {
                        this.model.saveItem(item, this._editingItemIndex);
                    } else {
                        this.model.addItem(item);
                    }
                }));
            },

            _onToggleItemEditor: function (item, index) {
                if (item === null && !this._isEmptyObject(this.defaultItem)) {
                    item = lang.mixin({}, this.defaultItem);    // defaultItem is from our editor descriptor metadata
                }
                this.inherited(arguments);  // item is part of arguments
            },
            // simple function to properly test if a JavaScript object is empty
            _isEmptyObject: function (obj) {
                var name;
                for (name in obj) {
                    if (obj.hasOwnProperty(name)) {
                        return false;
                    }
                }
                return true;
            }
        });
    });