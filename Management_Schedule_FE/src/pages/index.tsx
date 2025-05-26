import PageMetadata from "@/components/common/seo/page-metadata";
import HomePage from "@/components/features/guest/homePage";

export default function Home() {
  
  return (
    <>
      <PageMetadata
        title="Home"
        description="This is the home page of my awesome app."
      />
      <h1><HomePage/></h1>
    </>
  );
}
