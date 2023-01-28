import { useEffect, useState } from "react";
import slugify from "slugify";
import Modal from "react-modal";
import "../assets/skeleton.css";
import "../assets/normalize.css";

Modal.setAppElement("#root");

const styles = {
  modal: {
    overlay: {
      position: "fixed",
      width: "50rem",
      height: "40rem",
    },
    content: {
      width: "48rem",
      height: "28rem",
    },
  },
};

const UploadBlogPage = () => {
  const [header, setHeader] = useState("");
  const [slug, setSlug] = useState("");
  const [content, setContent] = useState("");
  const [modalIsOpen, setIsOpen] = useState(false);

  const defaultSlug = () => {
    if (header.length < 3) return;
    let endNum = header.length > 40 ? 40 : header.length;
    let dateTime = Date.now() as unknown as string;
    console.log("ylo");
    setSlug(
      slugify(header.substring(0, endNum) + "-" + dateTime, {
        replacement: "-",
      })
    );
    console.log("what");
  };

  const openModal = (e: { preventDefault: () => void }) => {
    e.preventDefault();
    setIsOpen(true);
    if (slug.length < 2) defaultSlug();
    if (header.length > 29 && content.length > 199)
      console.log("Have to implement");
  };
  const closeModal = () => {
    setIsOpen(false);
  };
  const checkAvailibility = (e: { preventDefault: () => void }) => {
    e.preventDefault();
  };

  const handleSubmit = (e: { preventDefault: () => void }) => {
    e.preventDefault();
    if (slug.length < 10) defaultSlug();
    // if(header.length>20&&)
  };

  return (
    <form onSubmit={handleSubmit} className="container" style={{ margin: 20 }}>
      <h1>Start your awesome blogs from here...✨✨✨</h1>
      <p>We support markdown</p>
      <label htmlFor="header">
        Post Heading
        <input
          type="text"
          name="header"
          id="header"
          className="header"
          value={header}
          size={100}
          style={{ width: "70vw", margin: "2vw" }}
          placeholder="min 20 characters"
          onChange={(e) => setHeader(e.target.value)}
        />
      </label>
      <div style={{ margin: 10 }}>
        <button onClick={openModal} type="submit">
          Modify Slug
        </button>
        <Modal
          isOpen={modalIsOpen}
          onRequestClose={closeModal}
          contentLabel="Slug Modal"
        >
          <input
            type="text"
            name="slug"
            id="slug"
            size={100}
            value={slug}
            onChange={(e) =>
              setSlug(slugify(e.target.value, { replacement: "-" }))
            }
          />
          <p></p>
          <button type="submit" onClick={closeModal} style={{ margin: 10 }}>
            close
          </button>
          <button onClick={checkAvailibility}> Is slug Avalable ?</button>
        </Modal>
      </div>
      <label htmlFor="">
        Blog Content
        <textarea
          name="content"
          id="content"
          cols={110}
          rows={110}
          style={{ width: "70vw", margin: "2vw" }}
          value={content}
          placeholder="min 100 character"
          onChange={(e) => setContent(e.target.value)}
        ></textarea>
      </label>
      <button type="submit">Post ✨</button>
    </form>
  );
};

export default UploadBlogPage;
