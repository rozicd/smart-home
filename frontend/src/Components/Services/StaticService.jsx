const API_BASE_URL = 'http://localhost:5090';

const getStaticContent = async (path) => {
  try {
    const response = await fetch(`${API_BASE_URL}/${path}`);

    if (!response.ok) {
      throw new Error(`Error fetching static content: ${response.statusText}`);
    }

    const contentType = response.headers.get('Content-Type');
    const data = await response.arrayBuffer();

    const blob = new Blob([data], { type: contentType });
    const dataUrl = URL.createObjectURL(blob);

    return dataUrl;
  } catch (error) {
    console.error('Error in getStaticContent:', error);
    throw error;
  }
};

export default getStaticContent;
