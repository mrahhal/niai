import { Metadata } from '@/models/metadata';
import { api } from '@/services/api';
import { Component, Vue } from 'vue-property-decorator';

@Component
export default class About extends Vue {
  private loading = true;
  private metadata!: Metadata;

  created() {
    api.getMetadata().then(metadata => {
      this.metadata = metadata;
      this.loading = false;
    });
  }
}
