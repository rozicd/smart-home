import { useEffect, useState } from "react";

const useFetch = (url, dependencies = []) => {
  const [data, setData] = useState({});
  const [error, setError] = useState(null);
  const [isLoading, setIsLoading] = useState(true);

  useEffect(() => {
    const fetchData = async () => {
      try {
        const dataPromises = Object.keys(callbacks).map(async (key) => {
          return { [key]: await callbacks[key]() };
        });

        const dataResults = await Promise.all(dataPromises);

        const mergedData = Object.assign({}, ...dataResults);

        setData(mergedData);
        console.log(data);
      } catch (error) {
        setError(error);
      } finally {
        setIsLoading(false);
      }
    };
    console.log(data);
    fetchData();
  }, dependencies);

  return { ...data, isLoading, error };
};

export default useFetch;