export default [
  'strapi::logger',
  'strapi::errors',
  'strapi::security',
  'strapi::cors',
  'strapi::poweredBy',
  'strapi::query',
  // 'strapi::body',
   {
    name: "strapi::body",
    config: {
      formLimit: "4gb", // modify form body
      jsonLimit: "4gb", // modify JSON body
      textLimit: "4gb", // modify text body
      formidable: {
        maxFileSize: 1024 * 1024 * 1024, // multipart data, modify here limit of uploaded file size
      },
    },
  },
  'strapi::session',
  'strapi::favicon',
  'strapi::public',
];
