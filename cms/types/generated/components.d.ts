import type { Schema, Struct } from '@strapi/strapi';

export interface BlocksForm extends Struct.ComponentSchema {
  collectionName: 'components_blocks_forms';
  info: {
    displayName: 'Form';
    icon: 'puzzle';
  };
  attributes: {
    form: Schema.Attribute.Relation<'oneToOne', 'api::form.form'>;
  };
}

export interface BlocksHero extends Struct.ComponentSchema {
  collectionName: 'components_blocks_heroes';
  info: {
    displayName: 'Hero';
    icon: 'feather';
  };
  attributes: {
    Description: Schema.Attribute.Text &
      Schema.Attribute.SetMinMaxLength<{
        maxLength: 1200;
      }>;
    Image: Schema.Attribute.Media<'images'>;
    PrimaryButton: Schema.Attribute.Component<'buttons.link', false>;
    SecondaryButton: Schema.Attribute.Component<'buttons.link', false>;
    Title: Schema.Attribute.String & Schema.Attribute.Required;
  };
}

export interface BlocksImage extends Struct.ComponentSchema {
  collectionName: 'components_blocks_images';
  info: {
    displayName: 'Image';
    icon: 'picture';
  };
  attributes: {
    Caption: Schema.Attribute.String;
    Image: Schema.Attribute.Media<'images'> & Schema.Attribute.Required;
  };
}

export interface BlocksOverview extends Struct.ComponentSchema {
  collectionName: 'components_blocks_overviews';
  info: {
    displayName: 'Overview';
    icon: 'grid';
  };
  attributes: {
    Entity: Schema.Attribute.Enumeration<['Events', 'Owners']> &
      Schema.Attribute.Required;
    Paginated: Schema.Attribute.Boolean &
      Schema.Attribute.Required &
      Schema.Attribute.DefaultTo<false>;
    Size: Schema.Attribute.Integer &
      Schema.Attribute.Required &
      Schema.Attribute.SetMinMax<
        {
          min: 1;
        },
        number
      > &
      Schema.Attribute.DefaultTo<10>;
  };
}

export interface BlocksTextBlock extends Struct.ComponentSchema {
  collectionName: 'components_blocks_text_blocks';
  info: {
    displayName: 'Text';
    icon: 'feather';
  };
  attributes: {
    Content: Schema.Attribute.Blocks & Schema.Attribute.Required;
    Title: Schema.Attribute.String;
  };
}

export interface ButtonsLink extends Struct.ComponentSchema {
  collectionName: 'components_buttons_links';
  info: {
    displayName: 'Link';
    icon: 'link';
  };
  attributes: {
    Internal: Schema.Attribute.Boolean &
      Schema.Attribute.Required &
      Schema.Attribute.DefaultTo<false>;
    InternalUrl: Schema.Attribute.Relation<'oneToOne', 'api::page.page'>;
    Title: Schema.Attribute.String & Schema.Attribute.Required;
    Url: Schema.Attribute.String;
  };
}

export interface FormFieldsCheckBox extends Struct.ComponentSchema {
  collectionName: 'components_form_fields_check_boxes';
  info: {
    displayName: 'CheckBox';
    icon: 'check';
  };
  attributes: {
    DefaultValue: Schema.Attribute.Boolean;
    Label: Schema.Attribute.String & Schema.Attribute.Required;
    Name: Schema.Attribute.String & Schema.Attribute.Required;
    Required: Schema.Attribute.Boolean &
      Schema.Attribute.Required &
      Schema.Attribute.DefaultTo<false>;
  };
}

export interface FormFieldsDatePicker extends Struct.ComponentSchema {
  collectionName: 'components_form_fields_date_pickers';
  info: {
    displayName: 'DatePicker';
    icon: 'calendar';
  };
  attributes: {
    DefaultValue: Schema.Attribute.Date;
    Label: Schema.Attribute.String & Schema.Attribute.Required;
    Name: Schema.Attribute.String & Schema.Attribute.Required;
    Required: Schema.Attribute.Boolean &
      Schema.Attribute.Required &
      Schema.Attribute.DefaultTo<false>;
  };
}

export interface FormFieldsDropDown extends Struct.ComponentSchema {
  collectionName: 'components_form_fields_drop_downs';
  info: {
    displayName: 'DropDown';
    icon: 'bulletList';
  };
  attributes: {
    Items: Schema.Attribute.Component<'form-utils.drop-down-item', true> &
      Schema.Attribute.Required &
      Schema.Attribute.SetMinMax<
        {
          min: 1;
        },
        number
      >;
    Label: Schema.Attribute.String & Schema.Attribute.Required;
    Name: Schema.Attribute.String & Schema.Attribute.Required;
    Required: Schema.Attribute.Boolean &
      Schema.Attribute.Required &
      Schema.Attribute.DefaultTo<false>;
  };
}

export interface FormFieldsEmail extends Struct.ComponentSchema {
  collectionName: 'components_form_fields_emails';
  info: {
    displayName: 'Email';
    icon: 'envelop';
  };
  attributes: {
    DefaultValue: Schema.Attribute.String;
    Label: Schema.Attribute.String & Schema.Attribute.Required;
    Name: Schema.Attribute.String & Schema.Attribute.Required;
    Required: Schema.Attribute.Boolean &
      Schema.Attribute.Required &
      Schema.Attribute.DefaultTo<false>;
  };
}

export interface FormFieldsInfo extends Struct.ComponentSchema {
  collectionName: 'components_form_fields_infos';
  info: {
    displayName: 'Info';
    icon: 'information';
  };
  attributes: {
    Message: Schema.Attribute.Text & Schema.Attribute.Required;
  };
}

export interface FormFieldsNumber extends Struct.ComponentSchema {
  collectionName: 'components_form_fields_numbers';
  info: {
    displayName: 'Number';
    icon: 'hashtag';
  };
  attributes: {
    DefaultValue: Schema.Attribute.String;
    Label: Schema.Attribute.String & Schema.Attribute.Required;
    Max: Schema.Attribute.Integer &
      Schema.Attribute.SetMinMax<
        {
          min: 1;
        },
        number
      >;
    Min: Schema.Attribute.Integer &
      Schema.Attribute.SetMinMax<
        {
          min: 0;
        },
        number
      >;
    Name: Schema.Attribute.String & Schema.Attribute.Required;
    Required: Schema.Attribute.Boolean &
      Schema.Attribute.Required &
      Schema.Attribute.DefaultTo<false>;
  };
}

export interface FormFieldsPassword extends Struct.ComponentSchema {
  collectionName: 'components_form_fields_passwords';
  info: {
    displayName: 'Password';
    icon: 'key';
  };
  attributes: {
    DefaultValue: Schema.Attribute.String;
    Label: Schema.Attribute.String & Schema.Attribute.Required;
    Name: Schema.Attribute.String & Schema.Attribute.Required;
    Required: Schema.Attribute.Boolean &
      Schema.Attribute.Required &
      Schema.Attribute.DefaultTo<false>;
  };
}

export interface FormFieldsText extends Struct.ComponentSchema {
  collectionName: 'components_form_fields_texts';
  info: {
    displayName: 'Text';
    icon: 'write';
  };
  attributes: {
    DefaultValue: Schema.Attribute.String;
    Label: Schema.Attribute.String & Schema.Attribute.Required;
    Name: Schema.Attribute.String & Schema.Attribute.Required;
    Required: Schema.Attribute.Boolean &
      Schema.Attribute.Required &
      Schema.Attribute.DefaultTo<false>;
  };
}

export interface FormFieldsTextArea extends Struct.ComponentSchema {
  collectionName: 'components_form_fields_text_areas';
  info: {
    displayName: 'TextArea';
    icon: 'write';
  };
  attributes: {
    DefaultValue: Schema.Attribute.Text;
    Label: Schema.Attribute.String & Schema.Attribute.Required;
    Name: Schema.Attribute.String & Schema.Attribute.Required;
    Required: Schema.Attribute.Boolean &
      Schema.Attribute.Required &
      Schema.Attribute.DefaultTo<false>;
  };
}

export interface FormFieldsTimeSelect extends Struct.ComponentSchema {
  collectionName: 'components_form_fields_time_selects';
  info: {
    displayName: 'TimeSelect';
    icon: 'clock';
  };
  attributes: {
    DefaultValue: Schema.Attribute.Time;
    Label: Schema.Attribute.String & Schema.Attribute.Required;
    Name: Schema.Attribute.String & Schema.Attribute.Required;
    Required: Schema.Attribute.Boolean &
      Schema.Attribute.Required &
      Schema.Attribute.DefaultTo<false>;
  };
}

export interface FormUtilsDropDownItem extends Struct.ComponentSchema {
  collectionName: 'components_form_utils_drop_down_items';
  info: {
    displayName: 'DropDown Item';
    icon: 'plus';
  };
  attributes: {
    Label: Schema.Attribute.String & Schema.Attribute.Required;
    Value: Schema.Attribute.String & Schema.Attribute.Required;
  };
}

declare module '@strapi/strapi' {
  export module Public {
    export interface ComponentSchemas {
      'blocks.form': BlocksForm;
      'blocks.hero': BlocksHero;
      'blocks.image': BlocksImage;
      'blocks.overview': BlocksOverview;
      'blocks.text-block': BlocksTextBlock;
      'buttons.link': ButtonsLink;
      'form-fields.check-box': FormFieldsCheckBox;
      'form-fields.date-picker': FormFieldsDatePicker;
      'form-fields.drop-down': FormFieldsDropDown;
      'form-fields.email': FormFieldsEmail;
      'form-fields.info': FormFieldsInfo;
      'form-fields.number': FormFieldsNumber;
      'form-fields.password': FormFieldsPassword;
      'form-fields.text': FormFieldsText;
      'form-fields.text-area': FormFieldsTextArea;
      'form-fields.time-select': FormFieldsTimeSelect;
      'form-utils.drop-down-item': FormUtilsDropDownItem;
    }
  }
}
