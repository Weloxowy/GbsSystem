declare module 'three/examples/jsm/loaders/MTLLoader' {
    import { LoadingManager } from 'three';
    import { Material } from 'three';
  
    export class MTLLoader {
      constructor(manager?: LoadingManager);
      load(
        url: string,
        onLoad?: (materials: Material) => void,
        onProgress?: (event: ProgressEvent) => void,
        onError?: (event: ErrorEvent) => void
      ): void;
      setMaterial(material: Material): this;
      setPath(path: string): this;
    }
  }
  