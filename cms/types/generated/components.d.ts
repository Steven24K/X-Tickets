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

declare module '@strapi/strapi' {
  export module Public {
    export interface ComponentSchemas {
      'blocks.hero': BlocksHero;
      'blocks.image': BlocksImage;
      'blocks.overview': BlocksOverview;
      'blocks.text-block': BlocksTextBlock;
      'buttons.link': ButtonsLink;
    }
  }
}
