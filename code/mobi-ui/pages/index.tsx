import type { NextPage } from "next";
import Head from "next/head";
import Link from "next/link";

const Home: NextPage = () => {
  return (
    <div>
      <Head>
        <title>Home Page</title>
      </Head>
      <main>
        <section className="p-6">
          <div className="tile is-ancestor">
            <div className="tile is-vertical is-8">

              <div className="tile">

                <div className="tile is-parent is-vertical">
                  <Link href="/stores">
                    <article className="tile is-child notification is-primary">
                      <p className="title">Stores</p>
                      <p className="subtitle">Mobi stores</p>
                    </article>
                  </Link>
                  <Link href="/products">
                    <article className="tile is-child notification is-warning">
                      <p className="title">Products</p>
                      <p className="subtitle">All products</p>
                    </article>
                  </Link>
                </div>

                <div className="tile is-parent">
                  <article>
                    <figure className="image">
                      <img src="https://img.freepik.com/free-photo/traditional-british-fish-with-chips-black-plate-black-background-space-text-top-view-flat-lay_109382-239.jpg?w=1480" />
                    </figure>
                  </article>
                </div>
              </div>
              <div className="tile is-parent">
                <article className="tile is-child notification is-danger">
                  <p className="title">Ads</p>
                  <p className="subtitle">Aligned with the right tile</p>
                  <div className="content"></div>
                </article>
              </div>

            </div>

            <div className="tile is-parent">
              <article className="tile is-child notification is-success">
                <div className="content">
                  <p className="title">Tall tile</p>
                  <p className="subtitle">With even more content</p>
                  <div className="content"></div>
                </div>
              </article>
            </div>
          </div>
        </section>
      </main>
    </div>
  );
};

export default Home;
