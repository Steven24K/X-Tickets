import type { Schema, Struct } from '@strapi/strapi';

export interface BlocksHero extends Struct.ComponentSchema {
  collectionName: 'components_blocks_heroes';
  info: {
    displayName: 'Hero';
    icon: 'feather';
  };
  attributes: {
    Description: Schema.Attribute.Text &
      Schema.Attribute.SetMinMaxLength<{
        maxLength: 120;
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
    Title: Schema.Attribute.String & Schema.Attribute.Required;
    Url: Schema.Attribute.String & Schema.Attribute.Required;
  };
}

declare module '@strapi/strapi' {
  export module Public {
    export interface ComponentSchemas {
      'blocks.hero': BlocksHero;
      'blocks.image': BlocksImage;
      'blocks.text-block': BlocksTextBlock;
      'buttons.link': ButtonsLink;
    }
  }
}
